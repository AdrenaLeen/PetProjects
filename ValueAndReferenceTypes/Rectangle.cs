using System;

namespace ValueAndReferenceTypes
{
    struct Rectangle
    {
        // Структура Rectangle содержит член ссылочного типа.
        public ShapeInfo rectInfo;

        public int rectTop, rectLeft, rectBottom, rectRight;

        public Rectangle(string info, int top, int left, int bottom, int right)
        {
            rectInfo = new ShapeInfo(info);
            rectTop = top;
            rectBottom = bottom;
            rectLeft = left;
            rectRight = right;
        }

        public void Display() => Console.WriteLine($"Строка = {rectInfo.infoString}, верх = {rectTop}, низ = {rectBottom}, лево = {rectLeft}, право = {rectRight}");
    }
}
