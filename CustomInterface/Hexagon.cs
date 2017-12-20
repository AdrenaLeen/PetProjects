using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    // Hexagon поддерживает IPointy и IDraw3D.
    class Hexagon : Shape, IPointy, IDraw3D
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine($"Отрисовка {PetName} класса Hexagon");
        }

        public void Draw3D()
        {
            Console.WriteLine("Отрисовка Hexagon в 3D!");
        }

        // Реализация IPointy.
        public byte Points
        {
            get { return 6; }
        }
    }
}
