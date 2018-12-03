using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegate
{
    public delegate void Display(string text);
    public class Operator
    {
        string text = "";
        string a = "";
        int a1 = 0, b1 = 0;
        string b = "";
        public Display invoker;
        public void Sum()
        {
            Console.WriteLine("Enter first number: ");
            a1 = Console.Read();
            //Console.ReadKey();
            //a = Console.ReadLine();
            Console.ReadKey();
            Console.WriteLine("Enter second number: ");
            //b = Console.ReadLine();
            b1 = Console.Read();
            text = (double.Parse(a) + double.Parse(b)).ToString();
            invoker.Invoke(text);

        }
    }
}
