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
            foreach (KeyValuePair<Edge,double> edge in edges)
            {
                if (edge.Key.p2 != currentLocation)
                {
                    return edge.Key.p2;
                }
                else
                {
                    return edge.Key.p1;
                }
                
            }
            return choosenPoint;
        }
    }
}
