namespace CustomInterfaces
{
    class Circle : Shape
    {
        public Circle() { }
        public Circle(string name) : base(name) { }
        public override void Draw() => Console.WriteLine($"Отрисовка {PetName} класса Circle");
    }
}
