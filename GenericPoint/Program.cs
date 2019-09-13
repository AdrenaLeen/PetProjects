using System;

namespace GenericPoint
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Обобщённые структуры *****");

            // Точка с координатами типа int.
            Point<int> p = new Point<int>(10, 10);
            Console.WriteLine($"p.ToString()={p}");
            p.ResetPoint();
            Console.WriteLine($"p.ToString()={p}");
            Console.WriteLine();

            // Точка с координатами типа double.
            Point<double> p2 = new Point<double>(5.4, 3.3);
            Console.WriteLine($"p2.ToString()={p2}");
            p2.ResetPoint();
            Console.WriteLine($"p2.ToString()={p2}");

            Console.ReadLine();
        }
    }
}
