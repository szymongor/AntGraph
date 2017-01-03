using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AntGraph
{
    struct Edge
    {
        public Point p1;
        public Point p2;

        public Edge reverse()
        {
            Edge edge;
            edge.p1 = p2;
            edge.p2 = p1;

            return edge;
        }

        public double length()
        {
            double length;
            length = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            return length;
        }
    }
}
