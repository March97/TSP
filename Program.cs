using System;

namespace TSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Euklidesowy problem komiwojażera");
            Console.WriteLine("");

            Generator g = new Generator();

            Vertice[] vertices = g.Generate(5);

            Matrix matrix = new (vertices);

            matrix.Print();
            Console.WriteLine("");

            NearestNeighbour nn = new (matrix);
            double x0 = nn.Run();
            nn.Print();
            Console.WriteLine("");

            BruteForce bf = new (matrix);
            double x = bf.Run();
            Console.WriteLine("");

            Accuracy acc = new Accuracy();
            Console.WriteLine("Błąd względny: " + acc.RelativeError(x, x0));
            Console.WriteLine("Błąd bezwzględny: " + acc.NonRelativeError(x, x0));

        }
    }
}
