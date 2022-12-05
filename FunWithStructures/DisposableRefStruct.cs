namespace FunWithStructures
{
    ref struct DisposableRefStruct
    {
        public int X;
        public readonly int Y;

        public readonly void Display() => Console.WriteLine($"X = {X}, Y = {Y}");

        // Специальный конструктор.
        public DisposableRefStruct(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
            Console.WriteLine("Экземпляр создан!");
        }

        // Выполнить здесь очистку любых ресурсов.
        public void Dispose() => Console.WriteLine("Экземпляр освобожден!");
    }
}
