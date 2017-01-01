using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}
