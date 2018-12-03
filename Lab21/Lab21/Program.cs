using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab21
{
    class Program
    {
        private static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Disketa.kz\Documents\Visual Studio 2017\input.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string a = sr.ReadToEnd();
            string[] numbers = a.Split(' ');
            int Mini = 2^31;
            int k = 0;
            for (int i = 1; i < numbers.Length; ++i)
            {
                if(int.Parse(numbers[i]) % i == 0)
                {
                    ++k;
                }
                if(k == 2)
                {
                    if (int.Parse(numbers[i]) < Mini)
                    {
                        Mini = int.Parse(numbers[i]);
                    }
                }
                k = 0;
            }
            Console.WriteLine(Mini);
            Console.ReadKey();
        }
    }
}
