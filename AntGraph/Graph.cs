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

        Dictionary<Edge, double> edges;

        public Graph()
        {
            vertices = new List<Point>();
            edges = new Dictionary<Edge, double>();
        }

        public void addVertex(Point p)
        {
            vertices.Add(p);
            if (vertices.Count > 3)
            {
                Edge edge;
                edge.p1 = vertices[0];
                edge.p2 = vertices[vertices.Count - 1];
                edges.Add(edge, 0.3);
            }
        }
        
        public List<Point> getVertices()
        {
            return vertices;
        }

        public Dictionary<Edge, double> getEdges()
        {
            return edges;
        }
    }
}
