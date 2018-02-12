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
        public void PrintNumbers()
        {
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
