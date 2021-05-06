using System;

namespace TSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Euklidesowy problem komiwojażera");

            Vertice v1 = new (0.0, 0.0);
            Vertice v2 = new (1.0, 0.0);
            Vertice v3 = new (0.0, 1.0);
            Vertice v4 = new (1.0, 1.0);
            Vertice v5 = new (3.0, 3.0);
            Vertice v6 = new (3.0, 0.0);
            Vertice v7 = new (0.0, 3.0);
            Vertice v8 = new (2.0, 2.0);

            Vertice[] vertices = { v1, v2, v3, v4, v5, v6, v7, v8 };

            Matrix matrix = new (vertices);

            matrix.Print();

            NearestNeighbour nn = new (matrix);
            nn.Print();

            //HeldKarp hk = new (matrix);

            BruteForce bf = new (matrix);

        }
    }
}
