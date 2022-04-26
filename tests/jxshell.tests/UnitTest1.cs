
using jxshell.dotnet4;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using System;
using System.IO;
using System.Linq;

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
            string file = environment.getCompilationFile("Teste_DeveCompilarCodigoEmArquivo");
            var f = new FileInfo(file);
            if (f.Exists)
            {
                f.Delete();
            }

            var codeString = GetCodeString();

            var cSharpLanguage = new csharplanguage();
            //var file = @"C:\Kodnet_Teste\compilados";
            cSharpLanguage.compileString(codeString, file);
            var assembly = cSharpLanguage.getCompiledAssembly();
            f.Refresh();

            Assert.NotNull(cSharpLanguage);
            Assert.NotNull(assembly);
            Assert.True(f.Exists);
        }

        [Fact]
        public void DeveCompilarCodigoEmString()
        {
            environment.initEnvironment();

            var codeString = GetCodeString();
            var cSharpLanguage = new csharplanguage();
            cSharpLanguage.runScript(codeString);
            var assembly = cSharpLanguage.getCompiledAssembly();
            Assert.NotNull(cSharpLanguage);
            //var person = new Person("teste", 18);
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