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
            jxshell.net4.SelfRegister.Register(typeof(jxshell.net4.Manager));
        }
    }
}
