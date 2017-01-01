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
            }
        }

        public void moveAnts()
        {
            foreach (Ant ant in ants)
            {
                
            }
        }

        public void moveAnt(Ant ant)
        {
            Point antLocation = ant.getLocation();
            Dictionary<Edge, double> edges = graph.getEdgesFromVertex(antLocation);
            Point antDestination = ant.choosePoint(edges);

        }


    }
}
