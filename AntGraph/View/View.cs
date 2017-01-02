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
        Graph graph;
        AntManager antManager;

        public View()
        {
            readyToDraw = false;
            InitializeComponent();
            canvas = pictureBox1.CreateGraphics();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = new Graph();
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
                    drawGraph(g);
                    drawEdges(g);
                    
                }
            }
        }

        private void drawGraph(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Lime);
            
            List<Point> pointsToDraw = graph.getVertices();
            foreach (Point p in pointsToDraw)
            {
                Rectangle area = new Rectangle(p.X-5, p.Y-5, 10, 10);
                g.FillEllipse(brush, area);
            }
        }

        private void drawBacground(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            Rectangle area = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            g.FillRectangle(brush, area);
        }

        private void drawEdges(Graphics g)
        {
            Dictionary<Edge, double> egdes = graph.getEdges();
            if (antManager != null)
            {
                egdes = antManager.getGraph().getEdges();
            }
            
            foreach (KeyValuePair<Edge, double> edge in egdes)
            {
                if ((float)edge.Value < 1)
                {
                    continue;
                }
                Pen pen = new Pen(Color.Lime,(float)edge.Value);
                g.DrawLine(pen, edge.Key.p1, edge.Key.p2);
            }
        }

        public void startAntSimulation(int antNumber)
        {
            antManager = new AntManager(graph, antNumber);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!readyToDraw)
            {
                return;
            }
            if (antManager != null)
            {
                antManager.moveAnts();
            }
            pictureBox1.Image = bitmap;
            pictureBox1.Update();
            drawScreen();
            i++;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int x = pictureBox1.PointToClient(MousePosition).X;
            int y = pictureBox1.PointToClient(MousePosition).Y;
            Point mousePoint = new Point(x,y);
            graph.addVertex(mousePoint);
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

    }
}
