using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace MultiThreadedPrinting
{
    // Все методы класса Printer теперь безопасны к потокам!
    [Synchronization]
    class Printer : ContextBoundObject
    {
        public void PrintNumbers()
        {
            // Вывести информацию о потоке.
            Console.WriteLine($"-> {Thread.CurrentThread.Name} выполняет PrintNumbers()");

            // Вывести числа.
            Console.Write("Ваши числа: ");
            for (int i = 0; i < 10; i++)
            {
                Random r = new Random();
                Thread.Sleep(100 * r.Next(5));
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
        }
    }
}
