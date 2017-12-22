using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHierarchy
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Простая иерархия интерфейсов *****");

            // Вызвать на уровне объекта.
            BitmapImage myBitmap = new BitmapImage();
            myBitmap.Draw();
            myBitmap.DrawInBoundingBox(10, 10, 100, 150);
            myBitmap.DrawUpsideDown();

            // Получить IAdvancedDraw явным образом.
            IAdvancedDraw iAdvDraw = myBitmap as IAdvancedDraw;
            if (iAdvDraw != null) iAdvDraw.DrawUpsideDown();

            Console.ReadLine();
        }
    }
}
