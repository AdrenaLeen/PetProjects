using System;

namespace MIInterfaceHierarchy
{
    class Rectangle : IShape
    {
        public int GetNumberOfSides()
        {
            return 4;
        }

        public void Draw()
        {
            Console.WriteLine("Отрисовка...");
        }

        public void Print()
        {
            Console.WriteLine("Печать...");
        }
    }
}
