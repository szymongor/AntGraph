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
        Point rootLocation;
        Point currentLocation;
        List<Point> visitedPoints;
        StatisticsManager statisticManager;
        double currentPathLength = 0;

        public Ant(Point currentLocation, StatisticsManager statisticManager)
        {
            this.statisticManager = statisticManager;
            this.rootLocation = currentLocation;
            this.currentLocation = currentLocation;
            visitedPoints = new List<Point>();
            visitedPoints.Add(currentLocation);
        }

        public Point getLocation()
        {
            return currentLocation;
        }

        public Point choosePoint(Dictionary<Edge, double> edges)
        {
            Dictionary<Edge, double> edgesToVisit = new Dictionary<Edge, double>();
            foreach (KeyValuePair<Edge, double> edge in edges)
            {
                if (visitedPoints.Contains(edge.Key.p2))
                {
                    continue;
                }
                edgesToVisit.Add(edge.Key, edge.Value);
            }
            if (edgesToVisit.Count == 0)
            {
                edgesToVisit = edges;
                visitedPoints.Clear();
                currentPathLength += Graph.verticesDistance(currentLocation, rootLocation);
                statisticManager.addScore(currentPathLength);
                currentPathLength = 0;
                return rootLocation;
            }

            double pheromoneAmount = 0;
            foreach (KeyValuePair<Edge, double> edge in edgesToVisit)
            {
                pheromoneAmount += 2*edge.Value + 1;     
            }

            Random random = new Random((int)DateTime.Now.Ticks);

            double rand = random.NextDouble() * pheromoneAmount;
            pheromoneAmount = 0;
            foreach (KeyValuePair<Edge, double> edge in edgesToVisit)
            {
                pheromoneAmount += 2*edge.Value + 1;
                if (pheromoneAmount > rand)
                {
                    currentPathLength += Graph.verticesDistance(currentLocation, edge.Key.p2);
                    return edge.Key.p2;
                }
            }

            return rootLocation;
        }

        public void moveAnt(Point point)
        {
            currentLocation = point;
            visitedPoints.Add(point);
        }
    }
}
