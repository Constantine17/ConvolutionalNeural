using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIforNeuron
{
    class Geometry
    {
        public double LengthBetweenPoints(double x0, double y0, double z0, double i0, double x1, double y1, double z1, double i1)
        {
            double lenght;
            //lenght = Math.Pow(x1 - x0, 2) + Math.Pow(y1 - y0, 2) + Math.Pow(z1 - z0, 2) + Math.Pow(i1 - i0, 2);
            lenght = (x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0) + (z1 - z0) * (z1 - z0) + (i1 - i0) * (i1 - i0);
            lenght = Math.Sqrt(lenght);
            return lenght;
        }
    }
}
