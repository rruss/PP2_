using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalStateMachine
{
    public delegate void Display(string result);
    public enum State
    {
        Zero,
        Accumulator,
        DecimalAccumulator,
        OneSidedOperators,
        Result,
        PendingCompute,
        Error
    }
    
    class Brain
    {
        public Display invoker;
        double memory = 0;
        public string number1 = "";
        public string number2 = "";
        public char lastitem = '.';

        public string result = "";
        public char op = '*';

        public char[] operations = { '+', '-', 'x', '/', '%' };
        public char[] onesidedoperations = { '±', '²', '√', 'R', '!' };
        public char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public char[] nozerodigits = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public char[] zero = { '0' };
        public char[] separators = { '.', ',' };
        public char[] clear = { 'C' };
        public char[] clearlastdigit = { '<' };
        public char[] equals = { '=' };
        public char[] memories = { 'c', 's', 'p', 'm', 'r' };


        State state = State.Zero;

        public void Process(char item)
        {
            switch (state)
            {
                case State.Zero:
                    Zero(item, false);
                    break;
                case State.Accumulator:
                    AccumulateDigits(item, false);
                    break;
                case State.DecimalAccumulator:
                    AccumulateDigitsWithSeparator(item, false);
                    break;
                case State.PendingCompute:
                    PendingCompute(item, false);
                    break;
                case State.Error:
                    Error(item, false);
                    break;
                case State.OneSidedOperators:
                    OneSidedOperations(item, false);
                    break;
                case State.Result:
                    Result(item, false);
                    break;
            }
        }

        public void Zero(char item, bool IsInput)
        {
            if (IsInput)
            {
                if(result != "")
                {
                    number1 = "";
                    number2 = "";
                    result = "0";
                    state = State.Zero;
                    invoker.Invoke(result);
                }
            }
            else
            {
                if (separators.Contains(item))
                {
                    AccumulateDigitsWithSeparator(item, true);
                }
                else if (nozerodigits.Contains(item))
                {
                    AccumulateDigits(item, true);
                }
                else if (clear.Contains(item))
                {
                    Zero(item, true);
                }
                else
                {

                }
            }
        }

        public void AccumulateDigits(char item, bool IsInput)
        {
            if (IsInput)
            {
                if (result == "0") result = "";
                if (number1 != "") number2 = number1;
                lastitem = item;
                result += item;
                state = State.Accumulator;
                invoker.Invoke(result);
            }
            else
            {
                if (digits.Contains(item))
                {
                    AccumulateDigits(item, true);
                }
                else if (separators.Contains(item))
                {
                    AccumulateDigitsWithSeparator(item, true);
                }
                else if (onesidedoperations.Contains(item))
                {
                    OneSidedOperations(item, true);
                }
                else if (operations.Contains(item))
                {
                    PendingCompute(item, true);
                }
                else if (memories.Contains(item))
                {
                    if (item == 's')
                    {
                        memory = double.Parse(result);
                    }
                    if (item == 'c')
                    {
                        memory = 0;
                    }
                    if (item == 'r')
                    {
                        result = memory.ToString();
                        invoker.Invoke(result);
                        
                    }
                    if (item == 'p')
                    {
                        memory = memory + double.Parse(result);
                    }
                    if (item == 'm')
                    {
                        memory = memory - double.Parse(result);
                    }
                }
                else if (equals.Contains(item))
                {
                    if(op != '*')
                    {
                        Result(item, true);
                    }
                    else
                    {
                        
                    }
                }
                else if (clear.Contains(item))
                {
                    Zero(item, true);
                }
                else if (clearlastdigit.Contains(item))
                {
                    if (result.Length > 0)
                    {
                        result = result.Remove(result.Length - 1);
                        invoker.Invoke(result);
                    }
                }
                else
                {

                }
            }

        }

        public void AccumulateDigitsWithSeparator(char item, bool IsInput)
        {
            if (IsInput)
            {

                if(result == "0")
                {
                    result = "0.";
                }
                else
                {
                    if (item == '.' && !result.Contains('.'))
                    {
                        lastitem = item;
                        result += '.';
                    }
                    else if(item == '.' && result.Contains('.'))
                    {
                        
                    }
                    else
                    {
                        result += item;
                    }
                }
                
                state = State.DecimalAccumulator;
                invoker.Invoke(result);
            }
            else
            {
                if (digits.Contains(item))
                {
                    AccumulateDigitsWithSeparator(item, true);
                }
                else if (separators.Contains(item))
                {
                    AccumulateDigitsWithSeparator(item, true);
                }
                else if (onesidedoperations.Contains(item))
                {
                    OneSidedOperations(item, true);
                }
                else if (operations.Contains(item))
                {
                    PendingCompute(item, true);
                }
                else if (equals.Contains(item))
                {
                    Result(item, true);
                }
                else if (clear.Contains(item))
                {
                    Zero(item, true);
                }
                else if (memories.Contains(item))
                {
                    if (item == 's')
                    {
                        memory = double.Parse(result);
                    }
                    if (item == 'c')
                    {
                        memory = 0;
                    }
                    if (item == 'r')
                    {
                        result = memory.ToString();
                        invoker.Invoke(result);
                    }
                    if (item == 'p')
                    {
                        memory = memory + double.Parse(result);
                    }
                    if (item == 'm')
                    {
                        memory = memory - double.Parse(result);
                    }
                }
                else if (clearlastdigit.Contains(item))
                {
                    if (result.Length > 0)
                    {
                        result = result.Remove(result.Length - 1);
                        invoker.Invoke(result);
                    }
                }
                else
                {

                }
            }
        }

        public void OneSidedOperations(char item, bool IsInput)
        {
            if (IsInput)
            {
                op = item;
                double b1 = double.Parse(result);
                double r = 0;
                
                if (op == '²')
                {
                    r = b1 * b1;
                }
                else if (op == '!')
                {
                    if (b1 == 0) r = 1;
                    else if(b1 < 0)
                    {
                        Error(item, true);
                    }
                    else
                    {
                        r = 1;
                        for(int i = 1; i <= b1; ++i)
                        {
                            r *= i;
                        }
                    }
                }
                else if (op == '√')
                {
                    r = Math.Sqrt(b1);
                }
                else if (op == 'R')
                {
                    r = 1 / b1;
                }
                else if (op == '±')
                {
                    r = b1 * (-1);
                }
                result = r.ToString();
                state = State.OneSidedOperators;
                invoker.Invoke(result);
                if((result == "NaN") || result == "Infinity")
                {
                    Error(item, true);
                }
            }
            else
            {
                if (digits.Contains(item))
                {
                    AccumulateDigits(item, true);
                }
                else if (separators.Contains(item))
                {
                    AccumulateDigitsWithSeparator(item, true);
                }
                else if (memories.Contains(item))
                {
                    if (item == 's')
                    {
                        memory = double.Parse(result);
                    }
                    if (item == 'c')
                    {
                        memory = 0;
                    }
                    if (item == 'r')
                    {
                        result = memory.ToString();
                        invoker.Invoke(result);
                    }
                    if (item == 'p')
                    {
                        memory = memory + double.Parse(result);
                    }
                    if (item == 'm')
                    {
                        memory = memory - double.Parse(result);
                    }
                }
                else if (onesidedoperations.Contains(item))
                {
                    OneSidedOperations(item, true);
                }
                else if (operations.Contains(item))
                {
                    PendingCompute(item, true);
                }
                else if (equals.Contains(item))
                {
                    Result(item, true);
                }
                else if (clear.Contains(item))
                {
                    Zero(item, true);
                }
                else if (clearlastdigit.Contains(item))
                {
                    if (result.Length > 0)
                    {
                        result = result.Remove(result.Length - 1);
                        invoker.Invoke(result);
                    }
                }
                else
                {

                }
            }
        }

        public void PendingCompute(char item, bool IsInput)
        {
            if (IsInput)
            {
                op = item;
                if (number2 != "")
                {
                    number1 = (double.Parse(result) + double.Parse(number2)).ToString();
                }
                else
                {
                    number1 = result;
                }
                result = "";
                state = State.PendingCompute;
                invoker.Invoke(result);
            }
            else
            {
                if (digits.Contains(item))
                {
                    AccumulateDigits(item, true);
                }
                else if (equals.Contains(item))
                {
                    result = number1;
                    Result(item, true);
                }
                else if (clear.Contains(item))
                {
                    Zero(item, true);
                }
                else if (memories.Contains(item))
                {
                    if (item == 's')
                    {
                        memory = double.Parse(result);
                    }
                    if (item == 'c')
                    {
                        memory = 0;
                    }
                    if (item == 'r')
                    {
                        result = memory.ToString();
                        invoker.Invoke(result);
                    }
                    if (item == 'p')
                    {
                        memory = memory + double.Parse(result);
                    }
                    if (item == 'm')
                    {
                        memory = memory - double.Parse(result);
                    }
                }
                else
                {

                }
            }
        }

        public void Result(char item, bool IsInput)
        {
            if (IsInput)
            {
                double a1 = double.Parse(number1);
                double a2 = double.Parse(result);
                double r = 0;

                if (op == '+')
                {
                    r = a1 + a2;
                }
                else if (op == '-')
                {
                    r = a1 - a2;
                }
                else if (op == 'x')
                {
                    r = a1 * a2;
                }
                else if (op == '/')
                {
                    r = a1 / a2;
                }
                else if (op == '%')
                {
                    r = (a1 * 100) / a2;
                }
                result = r.ToString();
                state = State.Result;
                invoker.Invoke(result);
            }
            else
            {
                if (zero.Contains(item))
                {
                    Zero(item, true);
                }
                else if (nozerodigits.Contains(item))
                {
                    result = "" + item;
                }
                else if (operations.Contains(item))
                {
                    PendingCompute(item, true);
                }
                else if (onesidedoperations.Contains(item))
                {
                    OneSidedOperations(item, true);

                }
                else if (separators.Contains(item))
                {
                    result = "0.";
                    AccumulateDigitsWithSeparator(item, true);
                }
                else if (clear.Contains(item))
                {
                    Zero(item, true);
                }
                else if (memories.Contains(item))
                {
                    if (item == 's')
                    {
                        memory = double.Parse(result);
                    }
                    if (item == 'c')
                    {
                        memory = 0;
                    }
                    if (item == 'r')
                    {
                        result = memory.ToString();
                        invoker.Invoke(result);
                    }
                    if (item == 'p')
                    {
                        memory = memory + double.Parse(result);
                    }
                    if (item == 'm')
                    {
                        memory = memory - double.Parse(result);
                    }
                }
                else if (clearlastdigit.Contains(item))
                {
                    if (result.Length > 0)
                    {
                        result = result.Remove(result.Length - 1);
                        invoker.Invoke(result);
                    }
                }
                else
                {

                }
            }
        }

        public void Error(char item, bool IsInput)
        {
            if (IsInput)
            {
                if ((result == "NaN") || result == "Infinity")
                {

                }
                else
                {
                    result = "ERROR!";
                }
                state = State.Error;

                invoker.Invoke(result);
            }
            else
            {
                if (clear.Contains(item))
                {
                    Zero(item, true);
                }
                else if (clearlastdigit.Contains(item))
                {
                    Zero(item, true);
                }
                else
                {

                }
            }

        }
    }

}
