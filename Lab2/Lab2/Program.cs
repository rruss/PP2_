using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Disketa.kz\Documents\Visual Studio 2017\input.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string a = sr.ReadToEnd();
            string[] numbers = a.Split(' ');
            int Maxi = int.Parse(numbers[0]);
            for(int i = 0; i < numbers.Length; ++i)
            {
                if(int.Parse(numbers[i]) > Maxi)
                {
                    Maxi = int.Parse(numbers[i]);
                }
            }

            int Mini = int.Parse(numbers[0]);
            for (int i = 0; i < numbers.Length; ++i)
            {
                if (int.Parse(numbers[i]) < Mini)
                {
                    Mini = int.Parse(numbers[i]);
                }
            }
            Console.WriteLine(Maxi + " " + Mini);
            Console.ReadKey();

        }
    }
    
}
