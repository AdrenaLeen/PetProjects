namespace GenericPoint
{
    // Обобщенная структура Point.
    public struct Point<T>
    {
        // Обобщенные данные состояния.
        public T? X { get; set; }
        public T? Y { get; set; }

        // Обобщенный конструктор.
        public Point(T xVal, T yVal)
        {
            X = xVal;
            Y = yVal;
        }

        public override string ToString() => $"[{X}, {Y}]";

        // Сбросить поля в стандартные значения для заданного параметра типа.
        // Ключевое слово default в языке C# перегружено. При использовании с обобщениями оно представляет стандартное значение для параметра типа.
        public void ResetPoint()
        {
            X = default;
            Y = default;
        }
    }
}
