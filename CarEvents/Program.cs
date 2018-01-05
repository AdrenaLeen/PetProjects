using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** События *****");
            Car c1 = new Car("СлагБаг", 100, 10);

            // Зарегистрировать обработчики событий.
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploded;

            Console.WriteLine("***** Увеличение скорости *****");
            for (int i = 0; i < 6; i++) c1.Accelerate(20);

            // Удалить метод CarExploded из списка вызовов.
            c1.Exploded -= CarExploded;

            Console.WriteLine("***** Увеличение скорости *****");
            for (int i = 0; i < 6; i++) c1.Accelerate(20);

            Console.ReadLine();
        }

        public static void CarAboutToBlow(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void CarIsAlmostDoomed(string msg)
        {
            Console.WriteLine($"=> Критическое сообщение от объекта Car: {msg}");
        }

        public static void CarExploded(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
