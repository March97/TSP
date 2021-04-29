using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Matrix
    {
        public double[,] matrix { get; set; }

        public Matrix(double[,] matrix)
        {
            this.matrix = matrix;
        }

        public Matrix(Vertice[] vertices)
        {
            this.matrix = new double[vertices.Length, vertices.Length];

            for (int i = 0; i < vertices.Length; i++)
            {
                for (int j = 0; j < vertices.Length; j++)
                {
                    this.matrix[i, j] = CalcDistance(vertices[i], vertices[j]);
                }
            }
        }

        private static double CalcDistance(Vertice v1, Vertice v2)
        {
            return Math.Sqrt(Math.Pow((v1.x - v2.x), 2) + Math.Pow((v1.y - v2.y), 2));
        }

        public void Print()
        {
            Console.Write("    ");
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("P" + j + "    ");
            }
            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("P" + i + "  ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0:N3}", matrix[i, j]) + " ");
                }
                Console.WriteLine();
            }
        }

        public double GetLength()
        {
            return matrix.GetLength(0);
        }

        public double GetElement(int x, int y)
        {
            return matrix[x, y];
        }
    }
}
