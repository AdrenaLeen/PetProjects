namespace MultiThreadedPrinting
{
    class Printer
    {
        // Маркер блокировки.
        private readonly object threadLock = new();
        public void PrintNumbers()
        {
            Monitor.Enter(threadLock);
            try
            {
                // Вывести информацию о потоке.
                Console.WriteLine($"-> {Thread.CurrentThread.Name} выполняет PrintNumbers()");

                // Вывести числа.
                Console.Write("Ваши числа: ");
                for (int i = 0; i < 10; i++)
                {
                    var r = new Random();
                    Thread.Sleep(100 * r.Next(5));
                    Console.Write($"{i}, ");
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(threadLock);
            }
            
        }
    }
}
