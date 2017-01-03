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
        double pheromoneDecay = 35;
        double pheromoneIncrement = 150;

        public AntManager(Graph graph, int antNumber)
        {
            pheromoneDecay = 0.7;
            this.graph = graph;
            ants = new List<Ant>();
            for (int i = 0; i < antNumber; i++)
            {
                Random rand = new Random((int)DateTime.Now.Ticks);
                int randInt = (int)(rand.NextDouble() * (graph.getVertices().Count));
                Ant ant = new Ant(graph.getVertices()[randInt]);
                ants.Add(ant);
            }
        }
        
        public void moveAnts()
        {
            graph.pheromoneDecay(pheromoneDecay);
            foreach (Ant ant in ants)
            {
                moveAnt(ant);
            }
        }

        public void setDecay(double coef)
        {
            pheromoneDecay = coef;
        }

        public void setIncrement(double coef)
        {
            pheromoneDecay = coef;
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
                graph.addEdge(edge, pheromoneIncrement);
            
        }
        
        public Graph getGraph()
        {
            return graph;
        }

    }
}
