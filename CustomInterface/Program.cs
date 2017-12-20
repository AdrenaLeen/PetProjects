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

            Console.ReadLine();
        }
    }
}
