using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Accuracy
    {
        public double NonRelativeError(double x, double x0)
        {
            return Math.Abs(x - x0);
        }

        public double RelativeError(double x, double x0)
        {
            return NonRelativeError(x, x0) / x;
        }
    }
}
