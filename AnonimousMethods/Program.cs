using System;

namespace AnonimousMethods
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Анонимные методы *****");
            int aboutToBlowCounter = 0;

            // Создать объект Car обычным образом.
            Car c1 = new Car("СлагБаг", 100, 10);

            // Зарегистрировать обработчики событий как анонимные методы.
            c1.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Эй! Слишком быстро!");
            };
            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine($"Сообщение от объекта Car: {e.msg}");
            };
            c1.Exploded += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine($"Критическое сообщение от объекта Car: {e.msg}");
            };

            // В конце концов, этот код будет инициировать события.
            for (int i = 0; i < 6; i++) c1.Accelerate(20);
            Console.WriteLine($"Событие AboutToBlow было инициировано {aboutToBlowCounter} раз.");

            Console.ReadLine();
        }
    }
}
