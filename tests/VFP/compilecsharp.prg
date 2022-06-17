* COMPILE C# CODE
*CLEAR 
? DATETIME()
?
ON SHUTDOWN QUIT
ON KEY LABEL ALT+F1 Quit
SET DEFAULT TO "c:\projetos\dotnet\desenvolvimento\vfp\jxshell.dotnet4.fork\tests\vfp\"
DO FULLPATH("kodnet.prg")
LOCAL engine

SET PATH TO C:\Users\User\kodnet\compilation ADDITIVE 

_screen.kodnet.loadAssembly("System.Collections")
_screen.kodnet.loadAssembly("System.Runtime")

lcCaminhoDlls = "D:\ProjetosDotNet\Testes\TESTE KODNET\TESTE InjecaoDependencia\ConsoleAppNetFramework48\ConsoleDependencyInjectionNET6_DLL_NET6\bin\x86\Release\net6.0\"
_screen.kodnet.loadAssemblyFile(lcCaminhoDlls + "Microsoft.Extensions.Hosting.dll")
_screen.kodnet.loadAssemblyFile(lcCaminhoDlls + "Microsoft.Extensions.Hosting.Abstractions.dll")
_screen.kodnet.loadAssemblyFile(lcCaminhoDlls + "Microsoft.Extensions.DependencyInjection.dll")


MESSAGEBOX('Vai executar engine = _screen.kodnet.getStaticWrapper("jxshell.csharplanguage").construct()')
cSharpLanguage = _screen.kodnet.getStaticWrapper("jxshell.csharplanguage").construct()

*TestePerson(engine)
TesteHost(cSharpLanguage)

ret = MESSAGEBOX('Finalizado COM SUCESSO!!!')
IF ret = 1
	CLEAR EVENTS
	CANCEL 
	QUIT 
ENDIF 
READ EVENTS

*--------------------------------------------------------------------------------------
FUNCTION TesteHost(cSharpLanguage)
*--------------------------------------------------------------------------------------
Local assembly, test, person

	m.code = GetCodeHost()
	manager = _Screen.dotnet4
	cSharpLanguage.Runscript(m.code)
	assembly = cSharpLanguage.getCompiledAssembly()
	*manager.loadAssembly(assembly)
	*SET STEP ON 
	location = assembly.Location
	*entry = assembly.GetEntryAssembly()
	? location

*!*		caminhoDlls = "D:\ProjetosDotNet\Testes\TESTE KODNET\TESTE InjecaoDependencia\ConsoleAppNetFramework48\ConsoleDependencyInjectionNET6_DLL_NET6\bin\x86\Release\net6.0\"
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.Hosting.dll")
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.Hosting.Abstractions.dll")
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.DependencyInjection.dll")
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.Configuration.Abstractions.dll")
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.DependencyInjection.Abstractions.dll")
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.Configuration.dll")
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.Primitives.dll")
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.FileProviders.Physical.dll")
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.FileProviders.Abstractions.dll")
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.Configuration.FileExtensions.dll")
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.Options.dll")
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.Logging.dll")
*!*	    manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.Logging.Abstractions.dll")

	manager.loadAssemblyFile(location)

	myHost = manager.getStaticWrapper("HostSample.MyHost").construct()
	myHost.SetMy()


	myHost.CreateHost()
	info = myHost.GetInfo()

*SET STEP ON 

	teste = myHost.Host
	? myHost.MyProperty
	
*--------------------------------------------------------------------------------------
FUNCTION GetCodeHost()
*--------------------------------------------------------------------------------------
LOCAL lcCode


** ATENÇÂO: no C# é utilizado duas aspas "" para indicar uma " na atribuição da string. Se simplesmente copiar o código do C# dá erro.

TEXT TO lcCode noshow

    using System;
    using System.Reflection;
    using System.Threading;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    namespace HostSample{
        public class MyHost{

            private string myProperty;
            public string MyProperty   
            {
                get { return myProperty; }
                set { myProperty = value; }
            }        

        	public IHost Host;
        
	        public void SetMy(){
	        	MyProperty = "Alterei a propriedade no SetMy";
	        }

	        public void CreateHost(){
	        	MyProperty = "Alterado no CreateHost";
	            var builder = new HostBuilder()
	            	.UseContentRoot(System.IO.Directory.GetCurrentDirectory());  // sem isso gera erro no VFP: The path must be absolute. (Parameter 'root')
	            Host = builder.Build();
			}
			
            public string GetInfo(){
                string info = "";
                info = info + "HostDefaults.ContentRootKey = " + HostDefaults.ContentRootKey + Environment.NewLine;
                info = info + "AppContext.BaseDirectory = " + AppContext.BaseDirectory + Environment.NewLine;
                info = info + "AppDomain.CurrentDomain.BaseDirectory = " + AppDomain.CurrentDomain.BaseDirectory + Environment.NewLine;
                info = info + "Thread.GetDomain().FriendlyName = " + Thread.GetDomain().FriendlyName + Environment.NewLine;
                //info = info + "Assembly.GetEntryAssembly().FullName = " + Assembly.GetEntryAssembly().FullName + Environment.NewLine;
                return info;
            }

        }
    }


ENDTEXT 
RETURN lcCode

*--------------------------------------------------------------------------------------
FUNCTION TestePerson(engine)
*--------------------------------------------------------------------------------------
Local asem, test, person

	m.code = GetCodePerson()
	m.engine.Runscript(m.code)
	asem = m.engine.getCompiledAssembly()
	*_Screen.kodnet.loadAssembly(asem)
	location = asem.Location
	_Screen.kodnet.loadAssemblyFile(location)

	* now you can use the type compiled 
	test= _screen.kodnet.getStaticWrapper("Compiled.Test").construct()
	person = test.CreatePerson("James", 24)
	? person.name
	? person.age

*--------------------------------------------------------------------------------------
FUNCTION GetCodePerson()
*--------------------------------------------------------------------------------------
LOCAL lcCode

TEXT TO lcCode noshow

	using System;
	public class program{
		public static void main(){
		}
	}
	namespace Compiled
	{

		public class Person{
			public string name;
			public int age;
		}
		
		public class Test
		{	
			public Person CreatePerson(string name, int age){
				var p= new Person();
				p.name= name;
				p.age= age;
				return p;
			}
		
			public static int ExecuteFunc(Func<string,int> func)
			{
				return func("Method executed from .NET");
			}
			
			public static int ExecuteFunc(Func<string,int> func, string message)
			{
				return func(message);
			}
			
			public static int ExecuteFunc(Func<string,int,string,int> func, string message, int option, string title)
			{
				return func(message,option,title);
			}
		}
	}
	
ENDTEXT 
RETURN lcCode