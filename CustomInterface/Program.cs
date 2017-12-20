using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Интерфейсы *****");

            // Обратиться к свойству Points, определённому в интерфейсе IPointy.
            Hexagon hex = new Hexagon();
            Console.WriteLine($"Количество вершин: {hex.Points}");

            // Перехватить возможное исключение InvalidCastException.
            Circle c = new Circle("Лиза");
            IPointy itfPt = null;
            try
            {
                itfPt = (IPointy)c;
                Console.WriteLine(itfPt.Points);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            // Можно ли hex2 трактовать как IPointy?
            Hexagon hex2 = new Hexagon("Питэр");
            IPointy itfPt2 = hex2 as IPointy;
            if (itfPt2 != null) Console.WriteLine($"Количество вершин: {itfPt2.Points}");
            else Console.WriteLine("Упс! Нет вершин...");

            Console.ReadLine();
        }
    }
}
