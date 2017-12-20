using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    // Circle поддерживает IDraw3D.
    class Circle : Shape, IDraw3D
    {
        public Circle() { }
        public Circle(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine($"Отрисовка {PetName} класса Circle");
        }

        public void Draw3D()
        {
            Console.WriteLine("Отрисовка Circle в 3D!");
        }
    }
}
