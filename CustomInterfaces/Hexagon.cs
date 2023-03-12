namespace CustomInterfaces
{
    class Hexagon : Shape, IPointy, IDraw3D
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw() => Console.WriteLine($"Отрисовка {PetName} класса Hexagon");
        public void Draw3D() => Console.WriteLine("Отрисовка Hexagon в 3D!");
        public byte Points => 6;
    }
}
