using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int k = int.Parse(btn.Text);
            k++;
            btn.Text = k.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button btn = new Button();
                    btn.Text = "0";
                    btn.Size = new Size(30, 30);
                    btn.Location = new Point(15 + j * 31, 15 + i * 31);
                    btn.Click += button1_Click;
                    Controls.Add(btn);
                }
            }
        }
    }
}
