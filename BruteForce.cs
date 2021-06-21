using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //calculate();
            //sw.Stop();
            //Console.WriteLine("Czas wykonania algorytmu BF: " + sw.ElapsedMilliseconds + " ms");

        }

        public double Run()
        {
            Stopwatch sw = new Stopwatch();
            long kbAtExecution = GC.GetTotalMemory(false) / 1024;
            sw.Start();
            double min = calculate();
            sw.Stop();
            long kbAfter1 = GC.GetTotalMemory(false) / 1024;
            Console.WriteLine("Czas wykonania algorytmu BF: " + sw.ElapsedMilliseconds + " ms");
            Console.WriteLine("Pamięć dodana w czasie algorytmu BF: " + (kbAfter1 - kbAtExecution) + "kB");
            return min;
        }

        private double calculate()
        {
            GetPer(toPermute);
            return getMin(pathsLength);
        }

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

        private static void Swap(ref int a, ref int b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        public void GetPer(int[] list)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x);
        }

        private void GetPer(int[] list, int k, int m)
        {
            if (k == m)
            {
                paths.Add(list);
                pathsLength.Add(distanceCalculation(list));
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }

    }
}
