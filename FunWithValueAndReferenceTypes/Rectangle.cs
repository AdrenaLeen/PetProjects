namespace FunWithValueAndReferenceTypes
{
    struct Rectangle
    {
        // Структура Rectangle содержит член ссылочного типа.
        public ShapeInfo RectInfo;

        public int RectTop, RectLeft, RectBottom, RectRight;

        public Rectangle(string info, int top, int left, int bottom, int right)
        {
            RectInfo = new ShapeInfo(info);
            RectTop = top;
            RectBottom = bottom;
            RectLeft = left;
            RectRight = right;
        }

        public void Display() => Console.WriteLine($"Строка = {RectInfo.InfoString}, Верх = {RectTop}, Низ = {RectBottom}, Лево = {RectLeft}, Право = {RectRight}");
    }
}
