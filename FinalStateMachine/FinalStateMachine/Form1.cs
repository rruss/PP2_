using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalStateMachine
{
    public partial class Form1 : Form
    {
        Brain fst = new Brain();
        void DisplayText(string text)
        {
            Textbox.Text = text;
        }

        public Form1()
        {
            InitializeComponent();
            fst.invoker = DisplayText;

        }

        private void digitbtnclck(object sender, EventArgs ar)
        {
            Button btn = sender as Button;
            char item = btn.Text[0];
            fst.Process(item);
        }

        private void opbtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            char item = btn.Text[0];
            fst.Process(item);
        }
        private void mem_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            char item = '.';
            string a = btn.Text;
            if(a == "MC")
            {
                item = 'c';
            }
            else if (a == "MR")
            {
                item = 'r';
            }
            else if (a == "MS")
            {
                item = 's';
            }
            else if (a == "M+")
            {
                item = 'p';
            }
            else if (a == "M-")
            {
                item = 'm';
            }
            fst.Process(item);
        }

        private void onesddopbtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            char item = '.';
            string ab = btn.Text;
            if(ab == "<--")
            {
                item = '<';
            }
            else if (ab == "n²")
            {
                item = '²';
            }
            else if (ab == "n!")
            {
                item = '!';
            }
            else if (ab == "√")
            {
                item = '√';
            }
            else if (ab == "1/n")
            {
                item = 'R';
            }
            else if (ab == "±")
            {
                item = '±';
            }
            fst.Process(item);
        }

        private void sprtbtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            char item = btn.Text[0];
            fst.Process(item);
        }

        private void eqbtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            char item = btn.Text[0];
            fst.Process(item);
        }
    }
}
