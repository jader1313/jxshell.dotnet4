using jxshell.dotnet4;

using System.Linq;
using System.Reflection;

using Xunit;

namespace jxshell.tests
{
    public class UnitTest1
    {
        [Fact]
        public void DeveCarregarDllNet6()
        {
            // TODO: precisamos de uma forma de compilar/enviar a DLL na versão requerida pelo teste
            var manager = new Manager();
            manager.init();
            manager.loadAssembly("System.Collections");
            manager.loadAssemblyFile(@"C:\Kodnet_Teste\Net6\Sinca.Integrador.Domain.dll");
            var arquivo = manager.getStaticWrapper("Sinca.Integrador.Domain.Arquivo");
            //var arquivoDto = manager.getStaticWrapper("Sinca.Integrador.Domain.Retorno.ArquivoRecebidoDto");
            //var arquivoObject = arquivo.construct();
            //var arquivoObject.NomeArquivo = "Nome do arquivo";

            Assert.NotNull(manager);
        }

        [Fact]
        public void DeveCarregarDllNetStandard2_0()
        {
            // TODO: precisamos de uma forma de compilar/enviar a DLL na versão requerida pelo teste
            var manager = new Manager();
            manager.init();
            manager.loadAssembly("System.Collections");
            manager.loadAssemblyFile(@"C:\Kodnet_Teste\Std2_0\Sinca.Integrador.Domain.dll");
            var arquivo = manager.getStaticWrapper("Sinca.Integrador.Domain.Arquivo");
            //var arquivoDto = manager.getStaticWrapper("Sinca.Integrador.Domain.Retorno.ArquivoRecebidoDto");
            //var arquivoObject = arquivo.construct();
            //var arquivoObject.NomeArquivo = "Nome do arquivo";
            Assert.NotNull(manager);
        }
        
        [Fact]
        public void DeveCompilarCodigoEmString()
        {
            var codeString = GetCodeString();

            var cSharpLanguage = new csharplanguage();
            cSharpLanguage.runScript(codeString);
            var asem = cSharpLanguage.getCompiledAssembly();


            Assert.NotNull(cSharpLanguage);
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
                        }
					}

					namespace Compiled
					{
						public class Person
                        {
							public string name;
							public int age;
						}
	
						public class Test
						{	
							public Person person(string name, int age)
                            {
								var p= new Person();
								p.name= name;
								p.age= age;
								return p;
							}
						}
					}
					";
        }


    }
}