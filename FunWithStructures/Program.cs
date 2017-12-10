using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithStructures
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Структуры *****");
            // Создать начальную переменную типа Point.
            Point myPoint;
            myPoint.X = 349;
            myPoint.Y = 76;
            myPoint.Display();

            // Скорректировать значения X и Y.
            myPoint.Increment();
            myPoint.Display();

            Console.ReadLine();
        }
    }
}
