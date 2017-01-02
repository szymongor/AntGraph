using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AntGraph
{
    class Ant
    {
        Point currentLocation;

        public Ant(Point currentLocation)
        {
            this.currentLocation = currentLocation;
        }

        public Point getLocation()
        {
            return currentLocation;
        }

        public Point choosePoint(Dictionary<Edge, double> edges)
        {
            Point choosenPoint = new Point(2, 3);
            double pheromoneAmount = 0;
            foreach (KeyValuePair<Edge,double> edge in edges)
            {
                pheromoneAmount += edge.Value + 1;     
            }

            Random random = new Random();

            double rand = random.NextDouble() * pheromoneAmount;
            pheromoneAmount = 0;
            foreach (KeyValuePair<Edge, double> edge in edges)
            {
                pheromoneAmount += edge.Value +1;
                if (pheromoneAmount > rand)
                {
                    return edge.Key.p2;
                }
            }

            return choosenPoint;
        }

        public void moveAnt(Point point)
        {
            currentLocation = point;
        }
    }
}
