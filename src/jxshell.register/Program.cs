using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jxshell.register
{
    public class Program
    {
        static void Main(string[] args)
        {
            jxshell.dotnet4.SelfRegister.Register(typeof(jxshell.dotnet4.Manager));
        }
    }
}
