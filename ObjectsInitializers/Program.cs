using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsInitializers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Синтаксис инициализации объектов *****");

            // Создать объект Point, устанавливая каждое свойство вручную.
            Point firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;
            firstPoint.DisplayStats();
            Console.WriteLine();

            // Создать объект Point посредством специального конструктора.
            Point anotherPoint = new Point(20, 20);
            anotherPoint.DisplayStats();
            Console.WriteLine();

            // Создать объект Point, используя синтаксис инициализации объектов.
            // Здесь стандартный конструктор вызывается неявно.
            Point finalPoint = new Point { X = 30, Y = 30 };
            finalPoint.DisplayStats();
            Console.WriteLine();

            // Здесь стандартный конструктор вызывается явно.
            Point finalPoint2 = new Point() { X = 30, Y = 30 };

            // Вызов специального конструктора.
            Point pt = new Point(10, 16) { X = 100, Y = 100 };

            // Вызов более интересного специального конструктора с помощью синтаксиса инициализации.
            Point goldPoint = new Point(PointColor.Gold) { X = 90, Y = 20 };
            goldPoint.DisplayStats();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
