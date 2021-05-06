﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class NearestNeighbour
    {
        private readonly Matrix matrix;
        private List<bool> visited;
        private List<int> path;
        private double length;


        public NearestNeighbour(Matrix matrix)
        {
            this.matrix = matrix;
            this.visited = new List<bool>();
            this.path = new List<int>();
            this.length = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            calculate();
            sw.Stop();
            Console.WriteLine("Czas wykonania algorytmu BF: " + sw.ElapsedMilliseconds + " ms");
        }

        private void calculate()
        {
            for (int i = 0; i < matrix.GetLength(); i++)
            {
                this.visited.Add(false);
            }

            //losowanie poczatkowego wierzcholka
            Random random = new Random();
            int lastVisited = random.Next(0, visited.Count - 1);
            int first = lastVisited;
            visited[lastVisited] = true;
            path.Add(lastVisited);

            while (visited.Contains(false))
            {
                double min = -1;
                int choice = -1;
                for (int i = 0; i < visited.Count; i++)
                {
                    if (visited[i] == false)
                    {
                        if (min < 0 || min > matrix.GetElement(lastVisited, i))
                        {
                            min = matrix.GetElement(lastVisited, i);
                            choice = i;
                        }
                    }
                }
                length += min;
                path.Add(choice);
                lastVisited = choice;
                visited[choice] = true;
            } 
            length += matrix.GetElement(lastVisited, first);
        }

        public void Print()
        {
            Console.Write("Wybrana ścieżka NN: ");
            foreach (int n in this.path)
            {
                Console.Write("P" + n + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Długość ścieżki NN: " + this.length);
        }
    }
}
