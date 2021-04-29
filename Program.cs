using System;

namespace TSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Euklidesowy problem komiwojażera");

            Vertice v1 = new (2.0, 3.0);
            Vertice v2 = new (5.5, 1.0);
            Vertice v3 = new (4.0, 4.5);
            Vertice v4 = new (1.3, 2.3);
            Vertice v5 = new (2.8, 3.0);

            Vertice[] vertices = { v1, v2, v3, v4, v5 };

            Matrix matrix = new (vertices);

            matrix.Print();

            NearestNeighbour nn = new NearestNeighbour(matrix);
            nn.Print();
        }
    }
}
