using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    // Класс Circle не переопределяет метод Draw().
    // Если не реализовать здесь абстрактный метод Draw(), то Circle также должен считаться абстрактным и быть помечен как abstract!
    class Circle : Shape
    {
        public Circle() { }
        public Circle(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine($"Отрисовка {PetName} класса Circle");
        }
    }
}
