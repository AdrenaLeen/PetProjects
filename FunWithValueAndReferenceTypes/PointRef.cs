namespace FunWithValueAndReferenceTypes
{
    // Классы всегда являются ссылочными типами.
    class PointRef
    {
        // Поля структуры.
        public int X;
        public int Y;

        // Специальный конструктор.
        public PointRef(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }

        // Добавить 1 к позиции (X, Y).
        public void Increment()
        {
            X++; Y++;
        }

        // Вычесть 1 из позиции (X, Y).
        public void Decrement()
        {
            X--; Y--;
        }

        // Отобразить текущую позицию.
        public void Display() => Console.WriteLine($"X = {X}, Y = {Y}");
    }
}
