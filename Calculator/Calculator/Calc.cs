using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    enum CalcStates
    {
        Firstnumber,
        Secondnumber
    }
    enum OperationStates
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        Sqrt,
        Power,
        Sign,
        Factorial,
        Reverse
    }
    class Calc
    {
        public double firstnumber;
        public double secondnumber;
        public double resultnumber;
        public int a;
        public double lastnumber;
        public CalcStates currentstate;
        public OperationStates currentoperation;
        public Calc()
        {
            currentstate = CalcStates.Firstnumber;
            firstnumber = 0;
            secondnumber = 0;
            resultnumber = 0;
            lastnumber = 0;
            a = 0;
        }
    }
}
