namespace SimpleDelegate
{
    // Этот класс содержит методы, на которые будет указывать BinaryOp.
    class SimpleMath
    {
        public int Add(int x, int y) => x + y;

        public static int Subtract(int x, int y) => x - y;

        public static int SquareNumber(int a) => a * a;
    }
}
