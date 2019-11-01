using System;
using System.Threading;

namespace AddWithThreads
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main()
        {
            Console.WriteLine("***** Сложение с помощью объектов Thread *****");
            Console.WriteLine($"Идентификатор потока в Main(): {Thread.CurrentThread.ManagedThreadId}");

            // Создать объект AddParams для передачи вторичному потоку.
            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);

            // Ожидать, пока не поступит уведомление!
            waitHandle.WaitOne();

            Console.WriteLine("Другой поток завершён!");
            Console.ReadLine();
        }

        static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine($"Идентификатор потока в Add(): {Thread.CurrentThread.ManagedThreadId}");
                AddParams ap = (AddParams)data;
                Console.WriteLine($"{ap.a} + {ap.b} равно {ap.a + ap.b}");

                // Сообщить другому потоку о том, что работа завершена.
                waitHandle.Set();
            }
        }
    }
}
