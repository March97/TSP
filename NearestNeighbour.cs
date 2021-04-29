using System;
using System.Collections.Generic;
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
            calculate();
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
            
        }

        public void Print()
        {
            Console.Write("Wybrana ścieżka: ");
            foreach (int n in this.path)
            {
                Console.Write("P" + n + " ");
            }
            Console.WriteLine();
            Console.Write("Długość ścieżki: " + this.length);
        }
    }
}
