using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Path
    {
        public List<int> vertices { get; set; }
        public double length { get; set; }

        public Path()
        {
            this.vertices = new List<int>();
            length = 0;
        }
    }
}
