using System;
using System.Threading;

namespace MultiThreadedPrinting
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Синхронизация потоков *****");

            Printer p = new Printer();

            // Создать 10 потоков, которые указывают на один и тот же метод того же самого объекта.
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++) threads[i] = new Thread(new ThreadStart(p.PrintNumbers)) { Name = string.Format($"Рабочий поток #{i}") };

            // Теперь запустить их все
            foreach (Thread t in threads) t.Start();
            Console.ReadLine();
        }
    }
}
