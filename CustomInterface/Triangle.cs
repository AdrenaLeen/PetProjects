using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    // Новый производный от Shape класс по имени Triangle.
    class Triangle : Shape, IPointy
    {
        public Triangle() { }
        public Triangle(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine($"Отрисовка {PetName} класса Triangle");
        }

        // Реализация IPointy.
        public byte Points
        {
            get { return 3; }
        }
    }
}
