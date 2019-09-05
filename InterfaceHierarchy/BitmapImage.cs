using System;

namespace InterfaceHierarchy
{
    class BitmapImage : IAdvancedDraw
    {
        public void Draw()
        {
            Console.WriteLine("Отрисовка...");
        }

        public void DrawInBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine("Отрисовка в контейнере...");
        }

        public void DrawUpsideDown()
        {
            Console.WriteLine("Отрисовка в перевёрнутом положении!");
        }
    }
}
