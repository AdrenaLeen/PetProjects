using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreadedPrinting
{
    class Printer
    {
        // Маркер блокировки.
        private object threadLock = new object();

        public void PrintNumbers()
        {
            // Использовать маркер блокировки.
            lock (threadLock)
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
}
