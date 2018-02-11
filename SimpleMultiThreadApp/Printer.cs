using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleMultiThreadApp
{
    class Printer
    {
        public void PrintNumbers()
        {
            // Вывести информацию о потоке.
            Console.WriteLine($"-> {Thread.CurrentThread.Name} выполняет PrintNumbers()");

            // Вывести числа.
            Console.Write("Ваши числа: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i}, ");
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}
