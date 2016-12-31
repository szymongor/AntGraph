using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AntGraph
{
    class Graph
    {
        List<Point> vertices;

        public Graph()
        {
            vertices = new List<Point>();
        }

        public void addVertex(Point p)
        {
            vertices.Add(p);
        }

        public List<Point> getVertices()
        {
            return vertices;
        }

    }
}
