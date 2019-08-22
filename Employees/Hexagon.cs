using System;

namespace Employees
{
    // Класс Hexagon переопределяет метод Draw().
    class Hexagon : Shape
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw() => Console.WriteLine($"Отрисовка {PetName} класса Hexagon");
    }
}
