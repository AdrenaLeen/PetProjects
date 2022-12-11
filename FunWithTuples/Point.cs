namespace FunWithTuples
{
    struct Point
    {
        // Поля структуры.
        public int X;
        public int Y;

        // Специальный конструктор.
        public Point(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }

        public void Deconstruct(out int XPos, out int YPos) => (XPos,YPos) = (X, Y);
    }
}
