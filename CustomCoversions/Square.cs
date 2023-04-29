namespace CustomCoversions
{
    public struct Square
    {
        public int Length { get; set; }

        public Square(int l) => Length = l;

        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++) Console.Write("*");
                Console.WriteLine();
            }
        }

        public override string ToString() => $"[Длина = {Length}]";

        // Rectangle можно явно преобразовать в Square.
        public static explicit operator Square(Rectangle r) => new() { Length = r.Height };

        public static explicit operator Square(int sideLength) => new() { Length = sideLength };

        public static explicit operator int(Square s) => s.Length;
    }
}
