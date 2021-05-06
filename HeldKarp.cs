using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class HeldKarp
    {
        private readonly Matrix matrix;
        //private List<List<double>> d;
        private double[,] dp;
        private List<int> path;

        public HeldKarp(Matrix matrix)
        {
            this.matrix = matrix;
            //this.d = new List<List<double>>();
            this.dp = new double[matrix.GetLength(), 1 << matrix.GetLength()];
            this.path = new List<int>();
            calcHeldKarp();
        }

        public void calcHeldKarp()
        {
            for (int i = 0; i < dp.GetLength(0); i++)
                for (int j = 0; j < dp.GetLength(1); j++)
                    dp[i, j] = 1e10f;

            dp[0, 1] = 0;
            for (int mask = 1; mask < (1 << matrix.GetLength()); mask++)
            {
                for (int lastNode = 0; lastNode < matrix.GetLength(); lastNode++)
                {
                    if ((mask & (1 << lastNode)) == 0)
                        continue;
                    for (int nextNode = 0; nextNode < matrix.GetLength(); nextNode++)
                    {
                        if ((mask & (1 << nextNode)) != 0)
                            continue;
                        dp[nextNode, mask | (1 << nextNode)] = Math.Min(
                                dp[nextNode, mask | (1 << nextNode)],
                                dp[lastNode, mask] + matrix.GetElement(lastNode, nextNode));
                    }
                }
            }
            double res = 1e10f;
            for (int lastNode = 0; lastNode < matrix.GetLength(); lastNode++)
                res = Math.Min(res, matrix.GetElement(lastNode, 0) + dp[lastNode, (1 << matrix.GetLength()) - 1]);
            Console.WriteLine("Długość drogi: " + res);
        }
    }
}
