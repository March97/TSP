using System;

namespace TSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Euklidesowy problem komiwojażera");

            Generator g = new Generator();

            Vertice[] vertices = g.Generate(12);

            Matrix matrix = new (vertices);

            matrix.Print();

            NearestNeighbour nn = new (matrix);
            nn.Print();

            //HeldKarp hk = new (matrix);

            BruteForce bf = new (matrix);

        }
    }
}
