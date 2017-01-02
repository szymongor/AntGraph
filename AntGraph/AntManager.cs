using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AntGraph
{
    class AntManager
    {
        Graph graph;
        List<Ant> ants;

        public AntManager(Graph graph, int antNumber)
        {
            this.graph = graph;
            ants = new List<Ant>();
            for (int i = 0; i < antNumber; i++)
            {
                Ant ant = new Ant(graph.getVertices()[0]);
                ants.Add(ant);
            }
        }

        public void moveAnts()
        {
            graph.pheromoneDecay();
            foreach (Ant ant in ants)
            {
                moveAnt(ant);
            }
        }

        private void moveAnt(Ant ant)
        {
            Point antLocation = ant.getLocation();
            Dictionary<Edge, double> edges = graph.getEdgesFromVertex(antLocation);
            Point antDestination = ant.choosePoint(edges);
            ant.moveAnt(antDestination);
            Edge edge;
            edge.p1 = antLocation;
            edge.p2 = antDestination;
            graph.addEdge(edge, 0.8);
        }
        
        public Graph getGraph()
        {
            return graph;
        }

    }
}
