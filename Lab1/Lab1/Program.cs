using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Student
    {
        
    }
    class Program
    {
        private static bool Prime(int a)
        {
            bool res = true;
            if (a == 1)
            {
                return false;
            }
            else if(a == 2)
            {
                return true;
            }
            for (int i = 2; i < a; ++i)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            string x = Convert.ToString(Console.ReadLine());
            string[] numbers = x.Split(' ');
            for(int i = 0; i < numbers.Length; ++i)
            {
                if (Prime(Convert.ToInt32(numbers[i])) == true)
                    Console.WriteLine(numbers[i] + " ");
            }
            Console.ReadKey();
            


        }
    }
}
