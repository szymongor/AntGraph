using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntGraph
{
    class StatisticsManager
    {
        List<double> antsScores;
        double min = 0;
        Point[] minimumPath;

        public StatisticsManager()
        {
            antsScores = new List<double>();
        }

        public void addScore(double score, Point[] path)
        {
            if (min == 0 || min > score)
            {
                minimumPath = path;
                min = score;
            }
            antsScores.Add(score);
        }

        public double getMinScore(){
            return min;
        }

        public Point[] getMinPath()
        {
            return minimumPath;
        }

        public double averagePathLength()
        {
            double averageLength = 0;
            int scoresSize = antsScores.Count;
            if (scoresSize == 0)
            {
                return 0;
            }
            for (int i = 0; i < scoresSize; i++)
            {
                averageLength += antsScores[i];
            }
            
            averageLength /= scoresSize;
            return averageLength;
        }
    }
}
