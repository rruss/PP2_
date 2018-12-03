using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab4
{
    class Programs
    {
        public static void F1()
        {
            FileStream fs = new FileStream(@"C:\Users\Disketa.kz\source\repos\Lab4\Lab4\Ser-Deser\data1.xml", 
                FileMode.Create, FileAccess.Write);

            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex s = new Complex(1.33,2.66);
            try
            {
                xs.Serialize(fs, s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }

            Console.WriteLine("done");
        }


        public static void F2()
        {
            FileStream fs = new FileStream(@"C:\Users\Disketa.kz\source\repos\Lab4\Lab4\Ser-Deser\data1.xml", 
                FileMode.Open, FileAccess.Read);

            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            try
            {
                Complex c = (Complex)xs.Deserialize(fs);
                Console.WriteLine("The given number is " + c);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }


        }
       
        static void Main(string[] args)
        {
            F1();
            F2();
            Console.WriteLine("Press any key to leave...");
            Console.ReadKey();
        }
    }
}
