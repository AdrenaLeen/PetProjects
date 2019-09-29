using System;

namespace CarEventsWithLambdas
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Лямбда-выражения *****");
            
            // Создать объект Car обычным образом.
            Car c1 = new Car("СлагБаг", 100, 10);

            // Привязаться к событиям с помощью лямбда-выражений.
            c1.AboutToBlow += (sender, e) => Console.WriteLine(e.msg);
            c1.Exploded += (sender, e) => Console.WriteLine(e.msg);

            // Увеличить скорость (это инициирует события).
            Console.WriteLine("***** Увеличение скорости *****");
            for (int i = 0; i < 6; i++) c1.Accelerate(20);

            Console.ReadLine();
        }
    }
}
