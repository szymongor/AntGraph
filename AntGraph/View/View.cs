using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntGraph.View
{
    public partial class View : UserControl
    {
        Graphics canvas;
        Bitmap bitmap;
        bool readyToDraw;
        int i = 0;

        public View()
        {
            readyToDraw = false;
            InitializeComponent();
            canvas = pictureBox1.CreateGraphics();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            readyToDraw = true;
            timer1.Enabled = true;
        }


        private void drawScreen()
        {
            if (readyToDraw)
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    drawBacground(g);
                    drawLine(g);
                    
                }
            }
        }

        private void drawLine(Graphics g)
        {
            Pen pen = new Pen(Color.LimeGreen);
            Point p1 = new Point(40+i,50+i);
            Point p2 = new Point(45,60);
            g.DrawLine(pen, p1, p2);
        }

        private void drawBacground(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            Rectangle area = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            g.FillRectangle(brush, area);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!readyToDraw)
            {
                return;
            }
            pictureBox1.Image = bitmap;
            pictureBox1.Update();
            drawScreen();
            i++;
        }



    }
}
