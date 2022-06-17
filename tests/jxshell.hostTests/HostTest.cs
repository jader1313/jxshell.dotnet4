using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using System.Text.RegularExpressions;

using Xunit;


namespace jxshell.hostTests
{
    public class HostTest
    {
        private const string CompilationPath = @"C:\Users\User\kodnet\compilation\";
        private const string DllNet6FullFileName = @"C:\Kodnet_Teste\Net6\Sinca.Integrador.Domain.dll";

        public string GetCodeString_MyHost()
        {
            return @"
                        using System;

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
            string fileName = "MyLib.dll";
            string fileFullPath = CompilationPath + fileName;
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
            string code = GetCodeString_MyHost();
            var tree = SyntaxFactory.ParseSyntaxTree(code);
            string fileName = "MyHost.dll";
            string fileFullPath = CompilationPath + fileName;
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

            var caminhoDlls = @"D:\ProjetosDotNet\Testes\TESTE KODNET\TESTE InjecaoDependencia\ConsoleAppNetFramework48\ConsoleDependencyInjectionNET6_DLL_NET6\bin\x86\Release\net6.0\";
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
                //var caminhoDlls = @"D:\ProjetosDotNet\Testes\TESTE KODNET\TESTE InjecaoDependencia\ConsoleAppNetFramework48\ConsoleDependencyInjectionNET6_DLL_NET6\bin\x86\Release\net6.0\";
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.Hosting.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.Hosting.Abstractions.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.DependencyInjection.dll");

                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.Configuration.Abstractions.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.DependencyInjection.Abstractions.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.Configuration.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.Primitives.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.FileProviders.Physical.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.FileProviders.Abstractions.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.Configuration.FileExtensions.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.Options.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.Logging.dll");
                alc.LoadFromAssemblyPath(caminhoDlls + "Microsoft.Extensions.Logging.Abstractions.dll");

                Assembly assembly = alc.LoadFromAssemblyPath(fileFullPath);
                //var type = assembly.GetType("HostSample.MyHost");
                dynamic obj = assembly.CreateInstance("HostSample.MyHost");
                obj.CreateHost();
                Assert.Equal("Alterado no CreateHost", obj.MyProperty);
                alc.Unload();
            }
            Assert.True(compilationResult.Success, "Não compilou corretamente!");
        }

    }
}