using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntGraph
{
    class StatisticsManager
    {
        List<double> antsScores;

        public StatisticsManager()
        {
            antsScores = new List<double>();
        }

        public void addScore(double score)
        {
            antsScores.Add(score);
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
