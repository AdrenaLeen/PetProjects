using System;
using System.Threading;

namespace ThreadStats
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Статистика о текущем потоке *****");

            // Получить имя текущего потока.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";

            // Показать детали обслуживающего домена приложения и контекста.
            Console.WriteLine($"Имя текущего домена приложения: {Thread.GetDomain().FriendlyName}");
            Console.WriteLine($"Идентификатор текущего контекста: {Thread.CurrentContext.ContextID}");

            // Вывести некоторую статистику о текущем потоке.
            Console.WriteLine($"Имя потока: {primaryThread.Name}");
            Console.WriteLine($"Запущен ли поток?: {primaryThread.IsAlive}");
            Console.WriteLine($"Приоритет потока: {primaryThread.Priority}");
            Console.WriteLine($"Состояние потока: {primaryThread.ThreadState}");
            Console.ReadLine();
        }
    }
}
