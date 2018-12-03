using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public delegate void Del(string message);
    class Program
    {
        
        public static void DelegateMethod(string message)
        {
            System.Console.WriteLine(message);
        }

        handler("Hello World");
        Del handler = DelegateMethod;

        
        
    } 
}
