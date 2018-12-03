using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public delegate void Drctn(bool drctnHor);
    public partial class Form1 : Form
    {
        public Drctn invoker;
        bool drctnHor = true; 
        int drctnCnt = 0;
        public Form1()
        {
            InitializeComponent();
            GameLogic gl = new GameLogic();
            this.Controls.Add(gl.p1);
            this.Controls.Add(gl.p2);
        }

        public void ChangeDirection(object sender, EventArgs e)
        {

            ++drctnCnt;
            if(drctnCnt % 2 == 1)
            {
                drctnHor = false;
            }
            else
            {
                drctnHor = true;
            }
            invoker.Invoke(drctnHor);
        }
    }
}
