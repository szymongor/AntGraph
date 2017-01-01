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
        }
        
        public List<Point> getVertices()
        {
            return vertices;
        }

        public Dictionary<Edge, double> getEdges()
        {
            return edges;
        }

        public Dictionary<Edge, double> getEdgesFromVertex(Point vertex)
        {
            Dictionary<Edge, double> edgesFromVertex = new Dictionary<Edge, double>();
            foreach (KeyValuePair<Edge, double>  edge in edges)
            {
                if (edge.Key.p1 == vertex)
                {
                    edgesFromVertex.Add(edge.Key,edge.Value);
                }
            }
            return edgesFromVertex;
        }

        public void addEdge(Edge edge, double value)
        {
            if (edges.ContainsKey(edge))
            {
                edges[edge] += value;
            }
            else
            {
                edges.Add(edge, value);
            }
        }

    }
}
