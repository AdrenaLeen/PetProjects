using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsInitializers
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int xVal, int yVal)
        {
            X = xVal;
            Y = yVal;
        }

        public Point() { }

        public void DisplayStats()
        {
            Console.WriteLine($"[{X}, {Y}]");
        }
    }
}
