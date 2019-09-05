using System;

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
            if (myBitmap is IAdvancedDraw iAdvDraw) iAdvDraw.DrawUpsideDown();

            Console.ReadLine();
        }
    }
}
