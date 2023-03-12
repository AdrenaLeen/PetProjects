namespace CustomInterfaces
{
    class Square : Shape, IRegularPointy
    {
        public Square() { }
        public Square(string name) : base(name) { }

        // Метод Draw() поступает из базового класса Shape.
        public override void Draw() => Console.WriteLine("Отрисовка квадрата");

        // Это свойство поступает из интерфейса IPointy.
        public byte Points => 4;
        
        // Это свойство поступает из интерфейса IRegularPointy.
        public int SideLength { get; set; }
        public int NumberOfSides { get; set; }

        // Свойство Perimeter не реализовано.
    }
}
