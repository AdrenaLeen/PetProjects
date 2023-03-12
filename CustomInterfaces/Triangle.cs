namespace CustomInterfaces
{
    class Triangle : Shape, IPointy
    {
        public Triangle() { }
        public Triangle(string name) : base(name) { }
        public override void Draw() => Console.WriteLine($"Отрисовка {PetName} класса Triangle");
        public byte Points => 3;
    }
}
