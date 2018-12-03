using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Calc calc = new Calc();
        public Form1()
        {
            InitializeComponent();
        }

        

        private void resultBtnClck(object sender, EventArgs e)
        {
            calc.currentstate = CalcStates.Firstnumber;
            calc.a = 0;
            calc.secondnumber = double.Parse(display.Text);

            switch (calc.currentoperation)
            {
                case OperationStates.Plus:
                    calc.resultnumber = calc.firstnumber + calc.secondnumber;
                    break;
                case OperationStates.Minus:
                    calc.resultnumber = calc.firstnumber - calc.secondnumber;
                    break;
                case OperationStates.Multiply:
                    calc.resultnumber = calc.firstnumber * calc.secondnumber;
                    break;
                case OperationStates.Divide:
                    calc.resultnumber = calc.firstnumber / calc.secondnumber;
                    break;
                case OperationStates.Reverse:
                    calc.resultnumber = 1 / calc.firstnumber;
                    break;
                case OperationStates.Sign:
                    calc.resultnumber = calc.firstnumber * (-1);
                    break;
                case OperationStates.Sqrt:
                    calc.resultnumber = Math.Sqrt(calc.firstnumber);
                    break;
                case OperationStates.Power:
                    calc.resultnumber = Math.Pow(calc.firstnumber, calc.secondnumber);
                    break;
                case OperationStates.Factorial:
                    calc.resultnumber = 1;
                    for(int i = 1; i <= calc.firstnumber; ++i)
                    {
                        calc.resultnumber *= i;
                    }
                    break;
                default:
                    break;
            }


            display.Text = calc.resultnumber.ToString();
        }

        private void operationBtn(object sender, EventArgs e)
        {
            Button operationBtn = sender as Button;

            if (operationBtn.Text == "+")
            {
                calc.currentoperation = OperationStates.Plus;
            }
            else if (operationBtn.Text == "-")
            {
                calc.currentoperation = OperationStates.Minus;
            }
            else if (operationBtn.Text == "*")
            {
                calc.currentoperation = OperationStates.Multiply;
            }
            else if (operationBtn.Text == "/")
            {
                calc.currentoperation = OperationStates.Divide;
            }
            else if (operationBtn.Text == "√")
            {
                calc.currentoperation = OperationStates.Sqrt;
            }
            else if (operationBtn.Text == "1/n")
            {
                calc.currentoperation = OperationStates.Reverse;
            }
            else if (operationBtn.Text == "n²")
            {
                calc.currentoperation = OperationStates.Power;
            }
            else if (operationBtn.Text == "n!")
            {
                calc.currentoperation = OperationStates.Factorial;
            }
            else if (operationBtn.Text == "±")
            {
                calc.currentoperation = OperationStates.Sign;
            }

            calc.lastnumber = calc.resultnumber; 
            calc.currentstate = CalcStates.Secondnumber;
            calc.a = 0;

            if (calc.resultnumber != 0)
            {
                calc.firstnumber = calc.resultnumber;
            }
            else
            {
                calc.firstnumber = double.Parse(display.Text);
            }

            display.Text = "0";
        }

        private void dgtbtnClck(object sender, EventArgs e)
        {
            Button dgtbtn = sender as Button;
            //calc.lastnumber = double.Parse(dgtbtn.Text);

            if (display.Text == "0")
            {
                if (dgtbtn.Text == ".")
                {
                    ++calc.a;
                    if(calc.a > 1)
                    {
                        
                    }
                    else
                    {
                        display.Text += dgtbtn.Text;
                    }
                }
                else
                {
                    display.Text = dgtbtn.Text;
                }
                
            }
            
            
            else
            {
                if (dgtbtn.Text == ".")
                {
                    ++calc.a;
                    if (calc.a > 1)
                    {

                    }
                    else
                    {
                        display.Text += dgtbtn.Text;
                    }
                }
                else
                {
                    display.Text = display.Text + dgtbtn.Text;
                }

            }

        }

        private void button24_Click(object sender, EventArgs e)
        {
            display.Text = "0";
        }

        private void button23_Click(object sender, EventArgs e)
        {

            display.Text = display.Text.Remove(display.Text.Length - 1);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            display.Text = calc.lastnumber.ToString();
        }
    }
}
