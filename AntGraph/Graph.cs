﻿using System;
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
            if (vertices.Contains(p))
            {
                return;
            }
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

        public Dictionary<Edge, double> getEdgesFromVertex(Point startVertex)
        {
            Dictionary<Edge, double> edgesFromVertex = new Dictionary<Edge, double>();
            foreach (Point vertex in vertices)
            {
                if (startVertex != vertex)
                {
                    Edge edge;
                    edge.p1 = startVertex;
                    edge.p2 = vertex;
                    if (edges.ContainsKey(edge))
                    {
                        edgesFromVertex.Add(edge, edges[edge]);
                    }
                    else if (edges.ContainsKey(edge.reverse()))
                    {
                        edgesFromVertex.Add(edge, edges[edge.reverse()]);
                    }
                    else
                    {
                        edgesFromVertex.Add(edge, 0);
                    }
                }
            }
            return edgesFromVertex;
        }

        public void addEdge(Edge edge, double value)
        {
            
            if (edges.ContainsKey(edge))
            {
                edges[edge] += value * (1 / edge.length());
            }
            else if (edges.ContainsKey(edge.reverse()))
            {
                edges[edge.reverse()] += value *(1/edge.length());
            }
            else
            {
                edges.Add(edge, value * (1/edge.length()));
            }

        }

        public static double verticesDistance(Point p1, Point p2)
        {
            double dist = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            return dist;
        }

        public void pheromoneDecay(double decayCoef)
        {
            Dictionary<Edge, double> newPheromones = new Dictionary<Edge, double>();
            foreach (KeyValuePair<Edge, double> edge in edges)
            {
                double newPheromone = edge.Value - decayCoef;
                if (newPheromone < 0) newPheromone = 0;
                newPheromones.Add(edge.Key, newPheromone);
            }
            edges = newPheromones;
        }
    }
}
