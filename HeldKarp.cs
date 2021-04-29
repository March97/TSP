using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class HeldKarp
    {
        private readonly Matrix matrix;
        private List<List<double>> d;


        public HeldKarp(Matrix matrix)
        {
            this.matrix = matrix;
            this.d = new List<List<double>>();
        }

        public void calcHeldKarp()
        {
            List<double> d0 = new List<double>();
            for (int i = 1; i < matrix.GetLength(); i++)
            {
                d0.Add(matrix.GetElement(0, i));
            }
            d.Add(d0);

            for (int i = 1; i < matrix.GetLength(); i++)
            {

            }
        }


    }
}
