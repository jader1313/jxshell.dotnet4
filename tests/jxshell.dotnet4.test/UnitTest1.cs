using Microsoft.VisualStudio.TestTools.UnitTesting;
using jxshell.dotnet4;
using System;

namespace jxshell.dotnet4.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var ast = new Ast();
            var manager = new Manager();
            manager.loadAssemblyFile(@"C:\Kodnet_Teste\Std2_0\Sinca.Integrador.Domain.dll");
            //manager.loadAssemblyFile(@"C:\Projetos\DotNet\Desenvolvimento\NOVOS\Sinca.Integrador\src\Sinca.Integrador.Domain\bin\Release\netstandard2.0\Sinca.Integrador.Domain.dll");
            var arquivo = manager.getStaticWrapper("Sinca.Integrador.Domain.Arquivo");
            //var MD5Hash = engine.getStaticWrapper("jxshell.csharplanguage");

            //var engine = "teste";
            var languageEngine = new languageEngine();

            //var MD5Hash = engine.getStaticWrapper("System.Security.Cryptography.MD5");
            //var MD5Hash = engine.getStaticWrapper("jxshell.csharplanguage");
            //var engine = "teste";

            Assert.IsNotNull(manager);
        }

        [TestMethod]
        public void DeveCarregarDllNetStandard2_0()
        {
            var manager = new Manager();
            manager.init();
            manager.loadAssembly("System.Collections");
            manager.loadAssemblyFile(@"C:\Kodnet_Teste\Std2_0\Sinca.Integrador.Domain.dll");
            var arquivo = manager.getStaticWrapper("Sinca.Integrador.Domain.Arquivo");
            //var arquivoDto = manager.getStaticWrapper("Sinca.Integrador.Domain.Retorno.ArquivoRecebidoDto");
            //var arquivoObject = arquivo.construct();
            //var arquivoObject.NomeArquivo = "Nome do arquivo";
            Assert.IsNotNull(manager);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var codeString = GetCodeString();

            var cSharpLanguage = new csharplanguage();
            cSharpLanguage.runScript(GetCodeString_UsingSystem());
            var asem = cSharpLanguage.getCompiledAssembly();

            Assert.IsNotNull(cSharpLanguage);
        }

        public string GetCodeString_UsingSystem()
        {
            return @"
                    using System;

                    namespace RoslynCompileSample
                    {
                        public class Writer
                        {
                            public void Write(string message)
                            {
                                Console.WriteLine(message);
                            }
                        }
                    }";
        }

        public string GetCodeString()
        {
            return @"

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
							public Person person(string name, int age){
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
