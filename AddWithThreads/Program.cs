using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AddWithThreads
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Сложение с помощью объектов Thread *****");
            Console.WriteLine($"Идентификатор потока в Main(): {Thread.CurrentThread.ManagedThreadId}");

            // Создать объект AddParams для передачи вторичному потоку.
            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);

            // Подождать, пока другой поток завершится.
            Thread.Sleep(5);

            Console.ReadLine();
        }

        static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine($"Идентификатор потока в Add(): {Thread.CurrentThread.ManagedThreadId}");
                AddParams ap = (AddParams)data;
                Console.WriteLine($"{ap.a} + {ap.b} равно {ap.a + ap.b}");
            }
        }
    }
}
