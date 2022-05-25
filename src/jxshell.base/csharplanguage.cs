using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace jxshell
{
    public class csharplanguage : language
	{
		private CompilerParameters compilerParameters = new CompilerParameters();
		public Assembly compiled = null;
		private string sourceDefault = "";
		private static Dictionary<string, int> compilations;
		private static Dictionary<string, Assembly> compileds;

		public override string languageName
		{
			get
			{
				return "c#";
			}
		}

		static csharplanguage()
		{
			csharplanguage.compilations = new Dictionary<string, int>(0);
			csharplanguage.compileds = new Dictionary<string, Assembly>(0);
		}

		public csharplanguage()
		{
			this.compilerParameters.GenerateInMemory = false;
			this.compilerParameters.GenerateExecutable = false;
		}

		public void compileString(string script, string file)
		{
			string[] locations = CreateLocations(environment.assemblies);
			this.compilerParameters.TreatWarningsAsErrors = false;
			if (file != "")
			{
				this.compilerParameters.OutputAssembly = file;
			}
			this.compilerParameters.ReferencedAssemblies.AddRange(locations);
			string scriptFileName = WriteScriptFile(script);
			string scriptFileName2 = WriteScriptFile(this.sourceDefault);
			{
				this.compiled = CompileAssemblyFromFiles(scriptFileName, scriptFileName2, this.compilerParameters);
			}
		}

		private static string[] CreateLocations(List<Assembly> assemblies)
		{
			string[] location = new string[assemblies.Count];
			for (int i = 0; i < assemblies.Count; i++)
			{
				if (assemblies[i] == null)
				{
					throw new Exception("No se pudo cargar uno o más ensamblados.");
				}
				location[i] = assemblies[i].Location;
			}

			return location;
		}

		private static string WriteScriptFile(string script)
		{
			string str = string.Concat(Path.GetTempPath(), environment.uniqueId(), ".cs");
			FileStream fileStream = new FileStream(str, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter streamWriter = new StreamWriter(fileStream);
			streamWriter.Write(script);
			streamWriter.Close();
			fileStream.Close();
			return str;
		}

        private Assembly CompileAssemblyFromFiles(string scriptFileName, string scriptFileName2, CompilerParameters compilerParameters)
        {
            CompileAssemblyFromFile(compilerParameters, scriptFileName);
            return Assembly.LoadFile(compilerParameters.OutputAssembly);
        }

		private void CompileAssemblyFromFile(CompilerParameters compilerParameters, string scriptFileName)
		{
            string sourceCode = File.ReadAllText(scriptFileName);
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            var runtimeDirectoryPath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
			var runtimeDirectory = Directory.GetParent(runtimeDirectoryPath);

			var compilationOptions = new CSharpCompilationOptions(Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary)
				.WithPlatform(Platform.X86);
			var references = CreateReferences(compilerParameters);

			var dllFileName = Path.GetFileNameWithoutExtension(compilerParameters.OutputAssembly) + ".dll";
			var pdbFileName = Path.Combine(Path.GetDirectoryName(compilerParameters.OutputAssembly), Path.GetFileNameWithoutExtension(compilerParameters.OutputAssembly) + ".pdb");

			var compilation = CSharpCompilation.Create(dllFileName)
				.WithOptions(compilationOptions)
				.AddReferences(references)
				.AddSyntaxTrees(syntaxTree);

			var result = compilation.Emit(compilerParameters.OutputAssembly, pdbFileName);
			if (!result.Success)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (Diagnostic codeIssue in result.Diagnostics)
				{
					string issue = $"ID: {codeIssue.Id}, Message: {codeIssue.GetMessage()}, Location: { codeIssue.Location.GetLineSpan()}, Severity: { codeIssue.Severity}";
					stringBuilder.AppendLine();
					stringBuilder.Append(issue);
				}
				if (stringBuilder.Length > 0)
				{
					File.Delete(compilerParameters.OutputAssembly);
					throw new Exception(stringBuilder.ToString());
				}
			}
		}

		public static MetadataReference[] CreateReferences(CompilerParameters options)
		{
			var path = Environment.CurrentDirectory;
			//var jxshellFileName = @"C:\Projetos\DotNet\Desenvolvimento\VFP\jxshell.dotnet4.fork\src\jxshell.dotnet4\bin\Debug\net6.0\jxshell.dotnet4.dll";
			var path2 = Path.GetDirectoryName(typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly.Location);
			var runtimeVersion = System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
			var runtimeDirectoryPath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
			var pathSystemCoreLib = typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly.Location;
			var pathSystemRunTime = Path.Combine(runtimeDirectoryPath, "System.Runtime.dll");
			var refPaths = new[]
            {
				//typeof(Enumerable).Assembly.Location,
				pathSystemRunTime,
				typeof(Console).GetTypeInfo().Assembly.Location,
				typeof(object).GetTypeInfo().Assembly.Location
			};
			var quantidadeAssembliesPadrao = refPaths.Length;

			Array.Resize(ref refPaths, quantidadeAssembliesPadrao + options.ReferencedAssemblies.Count);
            options.ReferencedAssemblies.CopyTo(refPaths, quantidadeAssembliesPadrao);
			var references = refPaths.Select(r => MetadataReference.CreateFromFile(r)).ToArray();
			return references;
        }

		public override Assembly getCompiledAssembly()
		{
			return this.compiled;
		}

		public CompilerParameters getCompilerParameters()
		{
			return this.compilerParameters;
		}

		public override void loadClass(string file)
		{
			int item = -1;
			try
			{
				item = csharplanguage.compilations[file];
			}
			catch (Exception exception)
			{
			}
			if (item == 0)
			{
				DateTime now = DateTime.Now;
				while (true)
				{
					if (((DateTime.Now - now).TotalMilliseconds >= 4000 ? true : item != 0))
					{
						break;
					}
					item = csharplanguage.compilations[file];
				}
				if (item == 0)
				{
					throw new TimeoutException(string.Concat("No se pudo compilar correctamente el archivo ", file, ". Se agoto el tiempo de espera para la sincronizacion de compilacion entre diferentes hilos."));
				}
			}
			if (item == 1)
			{
				this.compiled = csharplanguage.compileds[file];
			}
			else
			{
				csharplanguage.compilations[file] = 0;
				bool flag = true;
				string str = environment.uniqueId();
				string fileName = Path.GetFileName(file);
				string str1 = string.Concat(Path.GetDirectoryName(file), "/__jxshell__cache");
				string str2 = string.Concat(str1, "/", fileName, ".cache");
				string end = "";
				environment.mkDir(str1);
				if (System.IO.File.Exists(str2))
				{
					DateTime lastWriteTime = System.IO.File.GetLastWriteTime(str2);
					if (System.IO.File.GetLastWriteTime(file) <= lastWriteTime)
					{
						FileStream fileStream = new FileStream(str2, FileMode.Open, FileAccess.Read);
						StreamReader streamReader = new StreamReader(fileStream);
						end = streamReader.ReadToEnd();
						streamReader.Close();
						fileStream.Close();
						if (end != "")
						{
							flag = false;
						}
					}
				}
				if (!flag)
				{
					try
					{
						Assembly assembly = Assembly.LoadFile(end);
						this.compiled = assembly;
						csharplanguage.compilations[file] = 1;
						csharplanguage.compileds[file] = assembly;
					}
					catch (Exception exception1)
					{
						flag = true;
					}
				}
				if (flag)
				{
					end = environment.getCompilationFile(str);
					FileStream fileStream1 = new FileStream(file, FileMode.Open, FileAccess.Read);
					StreamReader streamReader1 = new StreamReader(fileStream1);
					string end1 = streamReader1.ReadToEnd();
					streamReader1.Close();
					fileStream1.Close();
					try
					{
						this.compileString(end1, end);
					}
					catch (Exception exception3)
					{
						Exception exception2 = exception3;
						csharplanguage.compilations[file] = -1;
						throw new Exception(string.Concat("No se pudo realizar la compilacion de ", file, ". ", exception2.ToString()), exception2);
					}
					csharplanguage.compilations[file] = 1;
					csharplanguage.compileds[file] = this.compiled;
					fileStream1 = new FileStream(str2, FileMode.OpenOrCreate, FileAccess.Write);
					StreamWriter streamWriter = new StreamWriter(fileStream1);
					fileStream1.SetLength((long)0);
					streamWriter.Write(end);
					streamWriter.Close();
					fileStream1.Close();
				}
				try
				{
				}
				catch (Exception exception4)
				{
				}
				try
				{
					MethodInfo method = this.compiled.GetType("program").GetMethod("mainLibrary");
					method.Invoke(null, new object[0]);
				}
				catch (Exception exception5)
				{
				}
			}
		}

		public override void runFile(string file)
		{
			this.loadClass(file);
			Type type = this.compiled.GetType("program");
			MethodInfo method = type.GetMethod("main", new Type[0]);
			method.Invoke(null, new object[0]);
		}
		
		public static string GetSHA1(String texto)
		{
			SHA1 sha1 = SHA1CryptoServiceProvider.Create();
			Byte[] textOriginal = Encoding.UTF8.GetBytes(texto);
			Byte[] hash = sha1.ComputeHash(textOriginal);
			StringBuilder cadena = new StringBuilder();
			foreach (byte i in hash)
			{
			  cadena.AppendFormat("{0:x2}", i);
			}
			return cadena.ToString();
		}
		
		public override void runScript(string script)
		{
			//string file = environment.getCompilationFile(GetSHA1(script));
			runScriptWithId(script, "JIT-" + GetSHA1(script));
		}
		
		public override void runScriptWithId(string script, string id)
		{
			Type type = null;
			string file = environment.getCompilationFile(id); 
			var f = new FileInfo(file);
			bool compile= true;
			if(f.Exists)
			{
				try{
					this.compiled = Assembly.LoadFile(file);
					type = this.compiled.GetType("program");	
					compile = false;
				}
				catch(Exception){}
				
			}
			if(compile){
				this.compilerParameters.GenerateInMemory = false;
				this.compileString(script, file);
				type = this.compiled.GetType("program");
			}
			if(type != null){
				MethodInfo method = type.GetMethod("main", new Type[0]);
				method.Invoke(null, new object[0]);	
			}
		}

		public void runScript(string script, bool inMemory)
		{
			this.compilerParameters.GenerateInMemory = inMemory;
			this.compileString(script, (inMemory ? "" : environment.getCompilationFile()));
			Type type = this.compiled.GetType("program");
			if(type != null){
				MethodInfo method = type.GetMethod("main", new Type[0]);
				method.Invoke(null, new object[0]);	
			}
		}
	}
}