namespace FunWithStructures
{
    readonly struct ReadOnlyPoint
    {
        // Поля структуры.
        public int X { get; }
        public int Y { get; }

        // Отобразить текущую позицию.
        public void Display() => Console.WriteLine($"X = {X}, Y = {Y}");

        public ReadOnlyPoint(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }
    }
}
