using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Operator op = new Operator();
            
            void Display(string text)
            {
                Console.WriteLine(text);
            }
            op.invoker = Display;
            Console.ReadKey();
        }
    }
}
