﻿using System;
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
        StatisticsManager statisticManager;

        public View()
        {
            readyToDraw = false;
            InitializeComponent();
            canvas = pictureBox1.CreateGraphics();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = new Graph();
            readyToDraw = true;
            timer1.Enabled = true;
            statisticManager = new StatisticsManager();
        }

        private void drawScreen()
        {
            if (readyToDraw)
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    drawBacground(g);
                    drawEdges(g);
                    drawGraph(g);
                    drawAverageScore(g);
                    drawMinScore(g);
                    drawSolution(g);
                }
            }
        }

        private void drawGraph(Graphics g)
        {
            Brush brush;
            List<Point> pointsToDraw = graph.getVertices();
            for (int i = 0; i < pointsToDraw.Count; i++ )
            {
                if (i == 0)
                {
                    brush = new SolidBrush(Color.AliceBlue);
                }
                else if (i == pointsToDraw.Count - 1)
                {
                    brush = new SolidBrush(Color.AliceBlue);
                }
                else
                {
                    brush = new SolidBrush(Color.Lime);
                }

                Point p = pointsToDraw[i];
                Rectangle area = new Rectangle(p.X - 5, p.Y - 5, 10, 10);
                g.FillEllipse(brush, area);
            }
        }

        private void drawBacground(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            Rectangle area = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            g.FillRectangle(brush, area);
        }

        private void drawAverageScore(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Lime);
            String s = "Average score: "+((int)statisticManager.averagePathLength()).ToString();
            Font drawFont = new Font("Arial", 12);
            PointF drawPoint = new PointF(30, 30);
            g.DrawString(s, drawFont, brush, drawPoint);
        }

        private void drawMinScore(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Lime);
            String s = "Minimum score: " + ((int)statisticManager.getMinScore()).ToString();
            Font drawFont = new Font("Arial", 12);
            PointF drawPoint = new PointF(30, 60);
            g.DrawString(s, drawFont, brush, drawPoint);
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
                if ((float)edge.Value < 0.5)
                {
                    continue;
                }
                Pen pen = new Pen(Color.Lime, (float)Math.Log10(edge.Value)*2);
                g.DrawLine(pen, edge.Key.p1, edge.Key.p2);
            }
        }

        private void drawSolution(Graphics g)
        {
            try
            {
                Point[] drawSolution = statisticManager.getMinPath();
                Pen pen = new Pen(Color.Red, 5);
                g.DrawLines(pen, drawSolution);
            }
            catch (Exception e)
            {
                return;
            }
            

        }

        //private void drawSolution(Graphics g)
        //{
        //    List<Point> vertices = graph.getVertices();
        //    int graphSize = graph.getVertices().Count;
        //    Point currentPoint = vertices[0];
        //    int i = 0;
        //    while (i < graphSize)
        //    {
        //        i++;
        //        Dictionary<Edge, double> edges = graph.getEdgesFromVertex(currentPoint);
        //        double maxPheromone = 0;
        //        Point maxDestPoint = currentPoint;
        //        foreach (KeyValuePair<Edge, double> edge in edges)
        //        {
        //            if (edge.Value > maxPheromone && vertices.Contains(edge.Key.p2))
        //            {
        //                maxPheromone = edge.Value;
        //                maxDestPoint = edge.Key.p2;
        //            }
        //        }
        //        Pen pen = new Pen(Color.Red, (float)Math.Log10(maxPheromone)*2);
        //        g.DrawLine(pen, currentPoint, maxDestPoint);
        //        vertices.Remove(currentPoint);
        //        currentPoint = maxDestPoint;

        //    }

        //}

        public void startAntSimulation(int antNumber)
        {
            antManager = new AntManager(graph, antNumber, statisticManager);
            readyToDraw = true;
        }

        public void stopAntSimulation()
        {
            //antManager = null;
            readyToDraw = false;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                drawBacground(g);
                drawSolution(g);
                drawGraph(g);
                drawAverageScore(g);
                drawMinScore(g);
            }
        }

        public void setPheromoneDecay(double coef)
        {
            if(antManager != null)
            antManager.setDecay(coef);
        }

        public void setPheromoneIncrement(double coef)
        {
            if (antManager != null)
                antManager.setIncrement(coef);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!readyToDraw)
            {
                //return;
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
