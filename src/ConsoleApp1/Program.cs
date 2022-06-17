//using jxshell.dotnet4;
//using System.Reflection;
//string file = @"C:\Users\User\kodnet\compilation\1FA0FEDCC79791DFE282331EAA2B3332CBB8DB92.DLL";
//string classe = "C1fa0fedcc79791dfe282331eaa2b3332cbb8db92";
//string classeStatic = "C1fa0fedcc79791dfe282331eaa2b3332cbb8db92_static";
//string nomeClasseStatic = string.Concat("jxshell.dotnet4.", classeStatic);
//Type _type = Assembly.LoadFile(file).GetType(nomeClasseStatic);
//var types = new Type[] { typeof(Type), typeof(typeDescriptor) };
////ConstructorInfo[] info = _type.GetConstructors();
////ConstructorInfo _constructor = info[0];
//ConstructorInfo _constructor = _type.GetConstructor(types);
////var compiledWrapper = (wrapperStatic)_constructor.Invoke(new object[] { this.type, this });

//using jxshell.dotnet4;

using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Loader;


//Console.WriteLine("Início");
//var assemblyFileName = @"C:\Users\User\kodnet\compilation\F771CDE0227EFA47C295018CBEC90B5DA173C38B.DLL";
//Console.WriteLine("Carregando assembly: {0}", assemblyFileName);
//var assembly = Assembly.LoadFile(assemblyFileName);
//var a = assembly.ExportedTypes;
//var b = assembly.GetTypes();
//Type type = assembly.GetType("jxshell.dotnet4.Cf771cde0227efa47c295018cbec90b5da173c38b_static");
//var manager = Activator.CreateInstance(type);
//var metodos = type.GetMethods();

////var teste = type.GetMethod.getWrapper();

//------------------------------------------------------------------------------------------------------------------------------------------------------

Console.WriteLine("Início");

//var alc = new AssemblyLoadContext("UmNomeQualquer", isCollectible: true);
var alc = AssemblyLoadContext.Default;

var jxshell4FullFileName = @"C:\Projetos\DotNet\Desenvolvimento\VFP\jxshell.dotnet4.fork\src\jxshell.dotnet4\bin\Debug\net6.0\jxshell.dotnet4.dll";
Console.WriteLine("Carregando assembly: {0}", jxshell4FullFileName);
Assembly assembly = alc.LoadFromAssemblyPath(jxshell4FullFileName);

var jxshellBaseFullFileName = @"C:\Projetos\DotNet\Desenvolvimento\VFP\jxshell.dotnet4.fork\src\jxshell.dotnet4\bin\Debug\net6.0\jxshell.base.dll";
Console.WriteLine("Carregando assembly: {0}", jxshellBaseFullFileName);
var assemblyBase = alc.LoadFromAssemblyPath(jxshellBaseFullFileName);

Type type = assembly.GetType("jxshell.dotnet4.Manager");
dynamic? manager = Activator.CreateInstance(type);
manager.init();
manager.loadAssembly("System.Collections");

// Dessa forma FUNCIONA
//var assem = alc.LoadFromAssemblyPath(@"C:\Kodnet_Teste\Net6\Sinca.Integrador.Domain.dll");
//dynamic obj = assem?.CreateInstance(string.Concat("Sinca.Integrador.Domain", ".", "Arquivo"), false, BindingFlags.Default, null, new object[] { "MyParameter" }, null, null);

// Dessa forma FUNCIONA
//dynamic obj = Activator.CreateInstanceFrom(@"C:\Kodnet_Teste\Net6\Sinca.Integrador.Domain.dll", "Sinca.Integrador.Domain.Arquivo", false, BindingFlags.Default, null, new object[] { "MyParameter" }, null, null).Unwrap();

// Dessa forma FUNCIONA
manager.loadAssemblyFile(@"C:\Kodnet_Teste\Net6\Sinca.Integrador.Domain.dll", alc);
Assembly assemblyDomain = AssemblyLoadContext.Default.Assemblies.FirstOrDefault(x => x.FullName.Contains("Sinca.Integrador.Domain"));
dynamic obj = assemblyDomain.CreateInstance("Sinca.Integrador.Domain.Arquivo", false, BindingFlags.Default, null, new object[] { "MyParameter" }, null, null);

Console.WriteLine("Caminho: " + obj.CaminhoArquivo);
Console.WriteLine("FIM");
//alc.Unload();


//------------------------------------------------------------------------------------------------------------------------------------------------------
// Esse é um exemplo tentendo refletir a chamada no VFP

//Console.WriteLine("Início");

//var jxshell4FullFileName = @"C:\Projetos\DotNet\Desenvolvimento\VFP\jxshell.dotnet4.fork\src\jxshell.dotnet4\bin\Debug\net6.0\jxshell.dotnet4.dll";
//Console.WriteLine("Carregando assembly: {0}", jxshell4FullFileName);
//var assembly = Assembly.LoadFile(jxshell4FullFileName);

////var jxshellBaseFullFileName = @"C:\Projetos\DotNet\Desenvolvimento\VFP\jxshell.dotnet4.fork\src\jxshell.dotnet4\bin\Debug\net6.0\jxshell.base.dll";
////Console.WriteLine("Carregando assembly: {0}", jxshellBaseFullFileName);
////var assemblyBase = Assembly.LoadFile(jxshellBaseFullFileName);


//var a = assembly.ExportedTypes;
//var b = assembly.GetTypes();
//Type type = assembly.GetType("jxshell.dotnet4.Manager");
//var manager = Activator.CreateInstance(type);
//var metodos = type.GetMethods();
//MethodInfo method = type.GetMethod("init");
//method.Invoke(manager, null);
//method = type.GetMethod("loadAssembly", new Type[] { typeof(string) });
//method.Invoke(manager, new object[] { "System.Collections" });
//method = type.GetMethod("loadAssembly", new Type[] { typeof(string) });
//method.Invoke(manager, new object[] { "System.CodeDom" });
//method = type.GetMethod("loadAssemblyFile");
//method.Invoke(manager, new object[] { @"C:\Kodnet_Teste\Std2_0\Sinca.Integrador.Domain.dll" });
//method = type.GetMethod("getStaticWrapper");
//var arquivoClass = method.Invoke(manager, new object[] { "Sinca.Integrador.Domain.Arquivo" });
//Console.WriteLine("FIM");

//------------------------------------------------------------------------------------------------------------------------------------------------------

//var arquivoObject = arquivoClass.construct("teste");
//arquivoObject.NomeArquivo = "Nome do arquivo"
//? arquivoObject.NomeArquivo




//var typeName = "jxshell.dotnet4.Manager2";
//Console.WriteLine("Creating instance of: {0}", typeName);
//var instancia = Activator.CreateInstance(Type.GetType(typeName),);

//string instanceSpec = "System.EventArgs;System.Random;" +
//    "System.Exception;System.Object;System.Version";

//string[] instances = instanceSpec.Split(';');
//Array instlist = Array.CreateInstance(typeof(object), instances.Length);
//object item;
//for (int i = 0; i < instances.Length; i++)
//{
//    // create the object from the specification string
//    Console.WriteLine("Creating instance of: {0}", instances[i]);
//    item = Activator.CreateInstance(Type.GetType(instances[i]));
//    instlist.SetValue(item, i);
//}
//Console.WriteLine("\nObjects and their default values:\n");
//foreach (object o in instlist)
//{
//    Console.WriteLine("Type:     {0}\nValue:    {1}\nHashCode: {2}\n",
//        o.GetType().FullName, o.ToString(), o.GetHashCode());
//}

//Console.WriteLine("FIM");
//Console.ReadLine();

//class Test
//{
//    public static void Main()
//    {
//        AppDomain currentDomain = AppDomain.CurrentDomain;

//        InstantiateMyType(currentDomain);   // Failed!

//        currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolver);

//        InstantiateMyType(currentDomain);   // OK!
//    }

//    static void InstantiateMyType(AppDomain domain)
//    {
//        try
//        {
//            // You must supply a valid fully qualified assembly name here.
//            domain.CreateInstance("Assembly text name, Version, Culture, PublicKeyToken", "MyType");
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine(e.Message);
//        }
//    }

//    // Loads the content of a file to a byte array.
//    static byte[] loadFile(string filename)
//    {
//        FileStream fs = new FileStream(filename, FileMode.Open);
//        byte[] buffer = new byte[(int)fs.Length];
//        fs.Read(buffer, 0, buffer.Length);
//        fs.Close();

//        return buffer;
//    }

//    static Assembly MyResolver(object sender, ResolveEventArgs args)
//    {
//        AppDomain domain = (AppDomain)sender;

//        // Once the files are generated, this call is
//        // actually no longer necessary.
//        EmitAssembly(domain);

//        byte[] rawAssembly = loadFile("temp.dll");
//        byte[] rawSymbolStore = loadFile("temp.pdb");
//        Assembly assembly = domain.Load(rawAssembly, rawSymbolStore);

//        return assembly;
//    }

//    // Creates a dynamic assembly with symbol information
//    // and saves them to temp.dll and temp.pdb
//    static void EmitAssembly(AppDomain domain)
//    {
//        AssemblyName assemblyName = new AssemblyName();
//        assemblyName.Name = "MyAssembly";

//        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

//        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MyModule");
//        TypeBuilder typeBuilder = moduleBuilder.DefineType("MyType", TypeAttributes.Public);

//        ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, null);
//        ILGenerator ilGenerator = constructorBuilder.GetILGenerator();
//        ilGenerator.EmitWriteLine("MyType instantiated!");
//        ilGenerator.Emit(OpCodes.Ret);

//        typeBuilder.CreateType();

//        //assemblyBuilder..Save("temp.dll");
//    }
//}



