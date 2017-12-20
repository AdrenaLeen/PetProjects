using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    // Класс Hexagon переопределяет метод Draw().
    class Hexagon : Shape, IPointy
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine($"Отрисовка {PetName} класса Hexagon");
        }

        // Реализация IPointy.
        public byte Points
        {
            get { return 6; }
        }
    }
}
