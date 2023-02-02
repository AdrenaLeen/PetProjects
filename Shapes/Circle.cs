using System;

namespace Shapes
{
    // Если не реализовать здесь абстрактный метод Draw(), то Circle также должен считаться абстрактным и быть помечен как abstract!
    class Circle : Shape
    {
        public Circle() { }
        public Circle(string name) : base(name) { }
        public override void Draw() => Console.WriteLine($"Отрисовка {PetName} класса Circle");
    }
}
