namespace ObjectsInitializers
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointColorEnum Color { get; set; }

        public Point(int xVal, int yVal)
        {
            X = xVal;
            Y = yVal;
            Color = PointColorEnum.Gold;
        }

        public Point(PointColorEnum ptColor) => Color = ptColor;

        public Point() : this(PointColorEnum.BloodRed) { }

        public void DisplayStats()
        {
            Console.WriteLine($"[{X}, {Y}]");
            Console.WriteLine($"Point является {Color}");
        }
    }
}
