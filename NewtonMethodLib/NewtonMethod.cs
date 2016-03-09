using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonMethodLib
{
    static public class NewtonMethod
    {
        static public double FindRoot(double number, double degree, double epsilon)
        {
            double x0 = 1.0, x1;

            x1 = (1 / degree) * ((degree - 1) * x0 + (number / Math.Pow(x0, degree - 1)));
            while (Math.Abs(x1 - x0) > epsilon)
            {
                x0 = x1;
                x1 = (1 / degree) * ((degree - 1) * x0 + (number / Math.Pow(x0, degree - 1)));
            }
            return x1;
        }
    }
}
