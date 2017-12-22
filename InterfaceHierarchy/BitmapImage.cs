using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
