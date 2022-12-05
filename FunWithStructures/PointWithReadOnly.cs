namespace FunWithStructures
{
    struct PointWithReadOnly
    {
        // Поля структуры.
        public int X;
        public readonly int Y;
        public readonly string Name;

        // Отобразить текущую позицию и название.
        public readonly void Display() => Console.WriteLine($"X = {X}, Y = {Y}, Название = {Name}");

        // Специальный конструктор.
        public PointWithReadOnly(int xPos, int yPos, string name)
        {
            X = xPos;
            Y = yPos;
            Name = name;
        }
    }
}
