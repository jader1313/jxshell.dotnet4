using jxshell.dotnet4;
using System.Reflection;

string file = @"C:\Users\User\kodnet\compilation\1FA0FEDCC79791DFE282331EAA2B3332CBB8DB92.DLL";
string classe = "C1fa0fedcc79791dfe282331eaa2b3332cbb8db92";
string classeStatic = "C1fa0fedcc79791dfe282331eaa2b3332cbb8db92_static";

string nomeClasseStatic = string.Concat("jxshell.dotnet4.", classeStatic);
Type _type = Assembly.LoadFile(file).GetType(nomeClasseStatic);
var types = new Type[] { typeof(Type), typeof(typeDescriptor) };

//ConstructorInfo[] info = _type.GetConstructors();
//ConstructorInfo _constructor = info[0];
ConstructorInfo _constructor = _type.GetConstructor(types);

//var compiledWrapper = (wrapperStatic)_constructor.Invoke(new object[] { this.type, this });
Console.WriteLine("Hello, World!");
