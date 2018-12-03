using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f2complex
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex thread1 = new Complex("Thread 1", 1);
            Complex thread2 = new Complex("Thread 2", 2);
            Complex thread3 = new Complex("Thread 3", 3);
            Complex thread4 = new Complex("Thread 4", 4);
            Complex thread5 = new Complex("Thread 5", 5);
            Console.ReadKey();
        }
    }
}
