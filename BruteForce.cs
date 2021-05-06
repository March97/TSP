using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class BruteForce
    {
        private readonly Matrix matrix;
        private int[] toPermute;
        private List<int[]> paths;
        private List<double> pathsLength;
        //private List<Path> paths;

        public BruteForce(Matrix matrix)
        {
            this.matrix = matrix;
            //this.paths = new List<Path>();
            this.paths = new List<int[]>();
            this.pathsLength = new List<double>();
            this.toPermute = new int[matrix.GetLength()];
            for(int i = 0; i < toPermute.Length; i++)
            {
                toPermute[i] = i;
            }
            calculate();
        }

        private void calculate()
        {
            heapPermutation(toPermute, toPermute.Length, toPermute.Length);
            getMin(pathsLength);
        }

        //public void Print()
        //{
        //    Console.Write("Wybrana ścieżka BF: ");
        //    foreach (int n in this.paths)
        //    {
        //        Console.Write("P" + n + " ");
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine("Długość ścieżki BF: " + this.length);
        //}

        double getMin(List<double> pathsLength)
        {
            double min = 1e10f;
            int choose = 0;

            for(int i = 0; i < pathsLength.Count; i++)
            {
                if (min > pathsLength[i])
                {
                    min = pathsLength[i];
                    choose = i;
                }
                    
            }

            Console.Write("Wybrana ścieżka BF: ");
            foreach (int n in this.paths[choose])
            {
                Console.Write("P" + n + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Długość ścieżki BF: " + min);

            return min;
        }

        double distanceCalculation(int[] a)
        {
            double sum = 0;
            for(int i = 0; i < a.Length; i++)
            {
                if(i + 1 >= a.Length)
                    sum += matrix.GetElement(a[i], a[0]);
                else
                    sum += matrix.GetElement(a[i], a[i + 1]);
            }
            return sum;
        }

        // Generating permutation using Heap Algorithm
        void heapPermutation(int[] a, int size, int n)
        {
            // if size becomes 1 then prints the obtained
            // permutation
            if (size == 1)
            {
                int[] b = new int[n];
                for (int i = 0; i < n; i++)
                    b[i] = a[i];
                paths.Add(b);
                pathsLength.Add(distanceCalculation(b));
            }

            for (int i = 0; i < size; i++)
            {
                heapPermutation(a, size - 1, n);

                // if size is odd, swap 0th i.e (first) and
                // (size-1)th i.e (last) element
                if (size % 2 == 1)
                {
                    int temp = a[0];
                    a[0] = a[size - 1];
                    a[size - 1] = temp;
                }

                // If size is even, swap ith and
                // (size-1)th i.e (last) element
                else
                {
                    int temp = a[i];
                    a[i] = a[size - 1];
                    a[size - 1] = temp;
                }
            }
        }

    }
}
