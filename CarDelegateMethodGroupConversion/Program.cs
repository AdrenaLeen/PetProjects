using System;

namespace CarDelegateMethodGroupConversion
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Групповые преобразования методов *****");
            Car c1 = new Car();

            // Зарегистрировать простое имя метода.
            c1.RegisterWithCarEngine(CallMeHere);

            Console.WriteLine("***** Увеличение скорости *****");
            for (int i = 0; i < 6; i++) c1.Accelerate(20);

            // Отменить регистрацию простого имени метода.
            c1.UnRegisterWithCarEngine(CallMeHere);

            // Уведомления больше не поступают!
            for (int i = 0; i < 6; i++) c1.Accelerate(20);

            Console.ReadLine();
        }

        static void CallMeHere(string msg) => Console.WriteLine($"=> Сообщение от объекта Car: {msg}");
    }
}
