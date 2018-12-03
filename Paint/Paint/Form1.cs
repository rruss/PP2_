using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    enum Tools
    {
        Pen,
        Fill,
        Rectangle,
        Circle,
        Triangle,
        Line
    }

    enum BmpCreationMode
    {
        AfterFill,
        FromFile,
        Init
    }

    public partial class Form1 : Form
    {
        Point firstPoint = default(Point);
        Point secondPoint = default(Point);
        Bitmap bmp = default(Bitmap);
        Graphics gfx = default(Graphics);
        Pen pen = new Pen(Color.Black, 1);

        Tools activeTool = Tools.Pen;

        public Form1()
        {
            InitializeComponent();
            SetupPictureBox(BmpCreationMode.Init, "");

            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void SetupPictureBox(BmpCreationMode mode, string fileName)
        {

            if (mode == BmpCreationMode.Init)
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
            else if (mode == BmpCreationMode.FromFile)
            {
                bmp = new Bitmap(Bitmap.FromFile(openFileDialog1.FileName));
            }

            gfx = Graphics.FromImage(bmp);

            if (mode == BmpCreationMode.Init)
            {
                gfx.Clear(Color.White);
            }

            pictureBox1.Image = bmp;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            if (activeTool == Tools.Fill)
            {
                //DFloodFill fill = new DFloodFill(pictureBox1, bmp.GetPixel(e.X, e.Y), pen.Color, firstPoint, bmp);
                //fill.Fill();

                /*MapFill mf = new MapFill();
                mf.Fill(gfx, firstPoint, pen.Color, ref bmp);
                SetupPictureBox(BmpCreationMode.AfterFill, "");*/
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                secondPoint = e.Location;

                switch (activeTool)
                {
                    case Tools.Pen:
                        gfx.DrawLine(pen, firstPoint, secondPoint);
                        firstPoint = secondPoint;
                        break;
                    case Tools.Fill:
                        break;
                    case Tools.Rectangle:
                        break;
                    case Tools.Circle:
                        break;
                    case Tools.Triangle:
                        break;
                    case Tools.Line:

                        break;
                    default:
                        break;
                }

                pictureBox1.Refresh();
            }
        }
        
        private void checkBox1_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Pen;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = float.Parse(numericUpDown1.Value.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Line;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Rectangle;

        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Circle;

        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Triangle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Fill;
        }

    }
}
