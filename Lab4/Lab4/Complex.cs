using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class Complex
    {
        public double a, b;

        public Complex(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public Complex() { }


        public override string ToString()
        {
            return Convert.ToString(a) + ", " + Convert.ToString(b);
        }
    }
}
