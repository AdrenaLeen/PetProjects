using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AddWithThreadsAsync
{
    class Program
    {
        static void Main()
        {
            AddAsync();
            Console.ReadLine();
        }

        private static async Task AddAsync()
        {
            Console.WriteLine("***** Сложение с помощью объектов Thread *****");
            Console.WriteLine($"Идентификатор потока в Main(): {Thread.CurrentThread.ManagedThreadId}");
            AddParams ap = new AddParams(10, 10);
            await Sum(ap);
            Console.WriteLine("Другой поток завершён!");
        }

        static async Task Sum(object data)
        {
            await Task.Run(() =>
            {
                if (data is AddParams)
                {
                    Console.WriteLine($"Идентификатор потока в Add(): {Thread.CurrentThread.ManagedThreadId}");
                    AddParams ap = (AddParams)data;
                    Console.WriteLine($"{ap.a} + {ap.b} равно {ap.a + ap.b}");
                }
            });
        }
    }
}
