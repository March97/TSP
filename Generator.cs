using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Generator
    {
        double max = 100;
        Vertice[] vertices;
        public Generator()
        {
        }

        public Vertice[] Generate(int n)
        {
            vertices = new Vertice[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                Vertice v = new Vertice(rnd.NextDouble() * max, rnd.NextDouble() * max);
                vertices[i] = v;
            }
            return vertices;
        }
    }
}
