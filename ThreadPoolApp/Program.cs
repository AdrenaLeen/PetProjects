using System;
using System.Threading;

namespace ThreadPoolApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Пул потоков CLR *****");

            Console.WriteLine($"Запущен главный поток. ThreadID = {Thread.CurrentThread.ManagedThreadId}");
            Printer p = new Printer();
            WaitCallback workItem = new WaitCallback(PrintTheNumbers);

            // Поставить в очередь метод 10 раз.
            for (int i = 0; i < 10; i++) ThreadPool.QueueUserWorkItem(workItem, p);

            Console.WriteLine("Все задачи поставлены в очередь.");
            Console.ReadLine();
        }

        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }
    }
}
