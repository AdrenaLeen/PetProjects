using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPoint
{
    class Program
    {
        static void Main()
        {
            // Точка с координатами типа int.
            Point<int> p = new Point<int>(10, 10);

            // Точка с координатами типа double.
            Point<double> p2 = new Point<double>(5.4, 3.3);
        }
    }
}
