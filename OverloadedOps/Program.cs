using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadedOps
{
    class Program
    {
        // Сложение и вычитание двух точек?
        static void Main()
        {
            Console.WriteLine("***** Перегрузка операторов *****");

            // Создать две точки.
            Point ptOne = new Point(100, 100);
            Point ptTwo = new Point(40, 40);
            Console.WriteLine($"ptOne = {ptOne}");
            Console.WriteLine($"ptTwo = {ptTwo}");

            // Сложить две точки, чтобы получить большую?
            Console.WriteLine($"ptOne + ptTwo: {ptOne + ptTwo}");

            // Вычесть одну точку из другой, чтобы получить меньшую?
            Console.WriteLine("ptOne - ptTwo: {0} ", ptOne - ptTwo);

            // Выводит [110, 110]
            Point biggerPoint = ptOne + 10;
            Console.WriteLine($"ptOne + 10 = {biggerPoint}");

            // Выводит [120, 120]
            Console.WriteLine($"10 + biggerPoint = {10 + biggerPoint}");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
