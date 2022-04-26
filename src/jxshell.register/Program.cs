using jxshell.dotnet4;

using System;

namespace jxshell.register
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando...");
            var type = typeof(Manager);
            Console.WriteLine("Type Manager: " + type);
            SelfRegister.Register(type);
            Console.WriteLine("FIM");
            Console.ReadLine();
        }
    }
}
