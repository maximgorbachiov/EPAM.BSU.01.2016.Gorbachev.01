using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonMethodLib;

namespace NewtonMethodTest
{
    class Program
    {
        static void Main(string[] args)
        {
            double root = NewtonMethod.FindRoot(1000.0, 2.0, 0.00001);
            Console.WriteLine(root);
            Console.ReadLine();
        }
    }
}
