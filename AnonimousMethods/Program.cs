using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonimousMethods
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Анонимные методы *****");
            Car c1 = new Car("СлагБаг", 100, 10);

            // Зарегистрировать обработчики событий как анонимные методы.
            c1.AboutToBlow += delegate
            {
                Console.WriteLine("Эй! Слишком быстро!");
            };
            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine($"Сообщение от объекта Car: {e.msg}");
            };
            c1.Exploded += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine($"Критическое сообщение от объекта Car: {e.msg}");
            };

            // В конце концов, этот код будет инициировать события.
            for (int i = 0; i < 6; i++) c1.Accelerate(20);

            Console.ReadLine();
        }
    }
}
