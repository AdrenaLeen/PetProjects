using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShapes;
using My3DShapes;

namespace CustomNamespaces
{
    class Program
    {
        static void Main()
        {
            My3DShapes.Hexagon h = new My3DShapes.Hexagon();
            My3DShapes.Circle c = new My3DShapes.Circle();
            MyShapes.Square s = new MyShapes.Square();

            Console.ReadLine();
        }
    }
}
