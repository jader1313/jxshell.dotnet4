
using jxshell.dotnet4;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

using Xunit;
using System.Threading;

namespace jxshell.tests
{
    public class UnitTest1
    {
        private string DllNet6FullFileName = Path.GetFullPath(@"..\..\..\..\DLLs\Net6\Sinca.Integrador.Domain.dll");
        private string DllStd2_0FullFileName = Path.GetFullPath(@"..\..\..\..\DLLs\Std2_0\Sinca.Integrador.Domain.dll");
        private string CaminhoDlls = @"D:\ProjetosDotNet\Testes\TESTE KODNET\TESTE InjecaoDependencia\ConsoleAppNetFramework48\ConsoleDependencyInjectionNET6_DLL_NET6\bin\x86\Release\net6.0\";

        [Fact]
        public void KodnetGetStaticWrapper_SystemDecimal()
        {
            //Arrenge
            var manager = new Manager();
            manager.loadAssembly("System.Collections");
            manager.loadAssembly("System.Runtime");
            manager.loadAssembly("System.Private.CoreLib");
            manager.init();
            //manager.loadAssembly("System.Decimal");
            //Assembly assemblyName = new();
            //Act
            var systemDescinal = manager.getStaticWrapper("System.Decimal");
            //var systemDescinal = Construct(manager, "System", "System.Decimal");
            //var systemDescinal2 = Construct(assemblyName, "System", "Decimal");

            //Assert
            Assert.NotNull(systemDescinal);
        }

        [Fact]
        public void KodnetGetStaticWrapper()
        {
            var manager = new Manager();
            var nomeDll = Path.Combine(CaminhoDlls,"InjecaoDependenciaNET6.dll");
            manager.loadAssembly("System.Collections");
            manager.loadAssembly("System.Runtime");
            manager.loadAssemblyFile(nomeDll);
            manager.init();
            var nomeClasse = "InjecaoDependenciaNET6.DependencyInjection<InjecaoDependenciaNET6.MinhaClasse>";

            //var typeD = manager.loadTypeNoCompile(nomeClasse);
            //var helper = manager.vfpHelper(typeD);
            //var obj = helper.Construct();
            //var ast = helper.Compile();
            //var code = ast.code;
            //var staticName = ast.staticName;


            //var objMinhaClasse = obj..__invokeMethod("CriarInstanciaMinhaClasse");
        }
        //         typeD= _screen.__dotnet4.loadTypeNoCompile(m.type)
        //         helper = _screen.__dotnet4.vfpHelper(m.typeD)

        //         * compile class
        //         ast= m.helper.compile()
        //         helper = this.compile(m.ast, m.helper)
        //         * helper = this.create(m.helper)
        //this.helpers.Add(m.helper, m.type)
        //     ENDIF
        //     RETURN m.helper

        [Fact]
        public void DeveConstruirHost()
        {
            var codeString = GetCodeString_MyHost();
            Manager manager = NewInitializedManager();

            var caminhoDlls = CaminhoDlls;
            manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.Hosting.dll");
            manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.Hosting.Abstractions.dll");
            manager.loadAssemblyFile(caminhoDlls + "Microsoft.Extensions.DependencyInjection.dll");

            var cSharpLanguage = new csharplanguage();
            cSharpLanguage.runScript(codeString);
            var assembly = cSharpLanguage.getCompiledAssembly();
            //manager.loadAssembly(assembly);
            manager.loadAssemblyFile(assembly.Location);
            dynamic obj = Construct(assembly, "HostSample", "MyHost");
            obj.SetMy();
            obj.CreateHost();
            Assert.NotNull(obj);
            //Assert.NotNull(obj.Host);
        }

        private static dynamic Construct(Assembly assembly, string @namespace, string className, object[] args = null)
        {
            dynamic? obj = assembly?.CreateInstance(string.Concat(@namespace, ".", className), false, BindingFlags.Default, null, args, null, null);
            return obj;
        }

        private static dynamic Construct(Manager manager, string assemblyName, string className, object[] args = null)
        {
            wrapperStatic? wrapper = manager.getStaticWrapper(string.Concat(assemblyName, ".", className));
            //var assembly = manager.assemblies.FirstOrDefault(x => x.FullName.Contains(assemblyName));
            var assembly = wrapper.wrappedType.Assembly;
            dynamic? obj = assembly?.CreateInstance(string.Concat(assemblyName, ".", className), false, BindingFlags.Default, null, args, null, null);
            return obj;
        }

        private static Manager NewInitializedManager()
        {
            var manager = new Manager();
            manager.init();
            return manager;
        }

        [Fact]
        public void DeveCarregarDllNet6()
        {
            Manager manager = NewInitializedManager();
            manager.loadAssembly("System.Collections");
            manager.loadAssemblyFile(DllNet6FullFileName, new AssemblyLoadContext("TesteNet6", true));  // sem o novo contexto dá erro quando roda todos os testes ao mesmo tempo
            dynamic obj = Construct(manager, "Sinca.Integrador.Domain", "Arquivo", new object[] { "MyParameter" });
            Assert.Equal("MyParameter", obj?.CaminhoArquivo);
        }

        [Fact]
        public void DeveCarregarDllNetStandard2_0()
        {
            // TODO: precisamos de uma forma de compilar/enviar a DLL na versão requerida pelo teste
            var manager = new Manager();
            manager.init();
            manager.loadAssembly("System.Collections");
            manager.loadAssemblyFile(DllStd2_0FullFileName);
            var arquivo = manager.getStaticWrapper("Sinca.Integrador.Domain.Arquivo");
            //var arquivoDto = manager.getStaticWrapper("Sinca.Integrador.Domain.Retorno.ArquivoRecebidoDto");
            //var arquivoObject = arquivo.construct();
            //var arquivoObject.NomeArquivo = "Nome do arquivo";
            Assert.NotNull(manager);
        }

        [Fact]
        public void DeveCompilarEGerarArquivo()
        {
            environment.initEnvironment();
            string testClass = @"using System; 
            namespace test{

             public class tes
             {

               public string unescape(string Text)
              { 
                return Uri.UnescapeDataString(Text);
              } 

             }

            }";
            var runtimeDirectoryPath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
            var runtimeDirectory = Directory.GetParent(runtimeDirectoryPath);
            var newDirectory = runtimeDirectory.FullName + Path.DirectorySeparatorChar + "mscorlib.dll";
            var sourcesPath = Path.Combine(Environment.CurrentDirectory, "Sources");

            var dd = typeof(Enumerable).Assembly.Location;
            var coreDir = Directory.GetParent(dd);

            var dllFileName = Guid.NewGuid().ToString() + ".dll";
            var compilation = CSharpCompilation.Create(dllFileName)
                .WithOptions(new CSharpCompilationOptions(Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(
                MetadataReference.CreateFromFile(typeof(Object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Uri).Assembly.Location),
                MetadataReference.CreateFromFile(coreDir.FullName + Path.DirectorySeparatorChar + "mscorlib.dll"),
                MetadataReference.CreateFromFile(coreDir.FullName + Path.DirectorySeparatorChar + "System.Runtime.dll")
                )
                .AddSyntaxTrees(CSharpSyntaxTree.ParseText(GetCodeString()));

            var eResult = compilation.Emit("Minha2.dll");
        }

        [Fact]
        public void DeveCompilarCodigoEmArquivo()
        {
            environment.initEnvironment();
            string fileName = environment.getCompilationFile("Teste_DeveCompilarCodigoEmArquivo");
            var fileInfo = new FileInfo(fileName);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }

            var codeString = GetCodeString();

            var cSharpLanguage = new csharplanguage();
            cSharpLanguage.compileString(codeString, fileName);
            var assembly = cSharpLanguage.getCompiledAssembly();
            fileInfo.Refresh();

            Assert.NotNull(cSharpLanguage);
            Assert.NotNull(assembly);
            Assert.True(fileInfo.Exists);
        }

        [Fact]
        public void DeveCompilarCodigoEmString()
        {
            var codeString = GetCodeString();
            Manager manager = NewInitializedManager();
            var cSharpLanguage = new csharplanguage();
            cSharpLanguage.runScript(codeString);
            var assembly = cSharpLanguage.getCompiledAssembly();
            manager.loadAssembly(assembly);
            dynamic obj = Construct(assembly, "Compiled", "Test");
            var person = obj.person("James", 24);

            Assert.NotNull(obj);
            Assert.Equal("James", person.Name);
            Assert.Equal(24, person.Age);
        }

        public string GetCodeString_UsingSystem()
        {
            return @"using System;";
        }

        public string GetCodeString()
        {
            return @"
					using System;
					public class program
                    {
						public static void main()
                        {
                            Console.WriteLine(""Um teste"");
                            //Console.ReadLine();
                        }
					}

					namespace Compiled
					{
						public class Person
                        {
							public string Name;
							public int Age;
						}
	
						public class Test
						{	
							public Person person(string name, int age)
                            {
								var p= new Person();
								p.Name= name;
								p.Age= age;
								return p;
							}
						}
					}
					";
        }


        public string GetCodeString_MyHost()
        {
            return @"
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
	        	                    MyProperty = ""Alterei a propriedade no SetMy"";
                                }

                                public void CreateHost(){
                                    MyProperty = ""Alterado no CreateHost"";
                                    var builder = new HostBuilder();
                                    Host = builder.Build();
                                }

                                public string GetInfo(){
                                    string info = """";
                                    info = info + ""HostDefaults.ContentRootKey = "" + HostDefaults.ContentRootKey + Environment.NewLine;
                                    info = info + ""AppContext.BaseDirectory = "" + AppContext.BaseDirectory + Environment.NewLine;
                                    info = info + ""AppDomain.CurrentDomain.BaseDirectory = "" + AppDomain.CurrentDomain.BaseDirectory + Environment.NewLine;
                                    info = info + ""Thread.GetDomain().FriendlyName = "" + Thread.GetDomain().FriendlyName + Environment.NewLine;
                                    info = info + ""Assembly.GetEntryAssembly().FullName = "" + Assembly.GetEntryAssembly().FullName + Environment.NewLine;
                                    return info;
                                }
                            }
                        }
                    ";
        }

        public string GetCodeString_MyClass()
        {
            return @"
                        using System;
                        using Sinca.Integrador.Domain;

                        namespace RoslynCompileSample{

                            public class MyClass{

                                public string MyProperty{ get { return ""My property sample text...""; } }

                                public string MyMethod(){ 
                                    var MyObject = new Arquivo(""MyParameter"");
                                    return ""My method sample text...""; 
                                } 

                            }
                        }
                    ";
        }

        [Fact]
        public void DynamicallyCompileAndRunCode()
        {
            // https://stackoverflow.com/questions/64365731/how-to-reference-another-dll-in-roslyn-dynamically-compiled-code

            string code = GetCodeString_MyClass();
            var tree = SyntaxFactory.ParseSyntaxTree(code);
            environment.initEnvironment();
            string fileName = "MyLib.dll";
            string fileFullPath = environment.getCompilationFile(fileName);
            var fileInfo = new FileInfo(fileFullPath);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            var assemblyPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
            List<MetadataReference> references = new List<MetadataReference>();
            references.Add(MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location));
            references.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "netstandard.dll")));
            references.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.Runtime.dll")));
            references.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.Private.CoreLib.dll")));

            var anotherDLLReference = MetadataReference.CreateFromFile(DllNet6FullFileName);
            references.Add(anotherDLLReference);

            var compilation = CSharpCompilation.Create(fileName)
                .WithOptions(
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(references)
                .AddSyntaxTrees(tree);
            EmitResult compilationResult = compilation.Emit(fileFullPath);
            if (compilationResult.Success)
            {
                // Load the assembly
                var alc = new AssemblyLoadContext("UmNomeQualquer", isCollectible: true);
                Assembly assembly = alc.LoadFromAssemblyPath(fileFullPath);
                var type = assembly.GetType("RoslynCompileSample.Myclass");
                var prop = type?.GetProperties();
                var all = prop?.Where(x => x.Name == "Hello");
                var info = all?.FirstOrDefault(x => x.DeclaringType == type) ?? all?.First();
                var method = info?.GetGetMethod();
                dynamic obj = assembly.CreateInstance("RoslynCompileSample.MyClass");
                //var r = method?.Invoke(obj, new object[] { });
                Assert.Equal("My property sample text...", obj.MyProperty);
                alc.Unload();
            }
            Assert.True(compilationResult.Success, "Não compilou corretamente!");
        }

        [Fact]
        public void DynamicallyCompileAndRunCodeHost()
        {
            string info = "";
            info = info + "HostDefaults.ContentRootKey = " + HostDefaults.ContentRootKey + Environment.NewLine;
            info = info + "AppContext.BaseDirectory = " + AppContext.BaseDirectory + Environment.NewLine;
            info = info + "AppDomain.CurrentDomain.BaseDirectory = " + AppDomain.CurrentDomain.BaseDirectory + Environment.NewLine;
            info = info + "Thread.GetDomain().FriendlyName = " + Thread.GetDomain().FriendlyName + Environment.NewLine;
            info = info + "Assembly.GetEntryAssembly().FullName = " + Assembly.GetEntryAssembly().FullName + Environment.NewLine;

            var b = Assembly.GetEntryAssembly();
            var c = b.GetName();
            var d = b.ToString();

            string code = GetCodeString_MyHost();
            var tree = SyntaxFactory.ParseSyntaxTree(code);
            environment.initEnvironment();
            string fileName = "MyHost.dll";
            string fileFullPath = environment.getCompilationFile(fileName);
            var fileInfo = new FileInfo(fileFullPath);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            var assemblyPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
            List<MetadataReference> references = new List<MetadataReference>();
            references.Add(MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location));
            references.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "netstandard.dll")));
            references.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.Runtime.dll")));
            references.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.Private.CoreLib.dll")));

            var caminhoDlls = CaminhoDlls;
            references.Add(MetadataReference.CreateFromFile(caminhoDlls + "Microsoft.Extensions.Hosting.dll"));
            references.Add(MetadataReference.CreateFromFile(caminhoDlls + "Microsoft.Extensions.Hosting.Abstractions.dll"));
            references.Add(MetadataReference.CreateFromFile(caminhoDlls + "Microsoft.Extensions.DependencyInjection.dll"));

            var compilation = CSharpCompilation.Create(fileName)
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(references)
                .AddSyntaxTrees(tree);
            EmitResult compilationResult = compilation.Emit(fileFullPath);
            if (compilationResult.Success)
            {
                var alc = new AssemblyLoadContext("UmNomeQualquer", isCollectible: true);
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.Hosting.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.Hosting.Abstractions.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.DependencyInjection.dll");
                Assembly assembly = alc.LoadFromAssemblyPath(fileFullPath);
                //var type = assembly.GetType("HostSample.MyHost");
                dynamic obj = assembly.CreateInstance("HostSample.MyHost");

                info = obj.GetInfo();
                //string basePath = AppContext.BaseDirectory;
                //string domainBasePath = AppDomain.CurrentDomain.BaseDirectory;
                //string callingDomainName = Thread.GetDomain().FriendlyName;
                //string exeAssembly = Assembly.GetEntryAssembly().FullName;
                var a = System.IO.Directory.GetCurrentDirectory();
                //new PhysicalFileProvider(_hostingEnvironment.ContentRootPath);
                var builder = new HostBuilder();
                IHost Host = builder.Build();

                obj.CreateHost();
                Assert.Equal("Alterado no CreateHost", obj.MyProperty);
                alc.Unload();
            }
            Assert.True(compilationResult.Success, "Não compilou corretamente!");
        }

    }
}