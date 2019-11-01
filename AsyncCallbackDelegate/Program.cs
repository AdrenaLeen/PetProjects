using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace AsyncCallbackDelegate
{
    public delegate int BinaryOp(int x, int y);

    class Program
    {
        private static bool isDone = false;

        static void Main()
        {
            Console.WriteLine("***** Пример делегата AsyncCallback *****");
            Console.WriteLine($"Main() вызывается в потоке {Thread.CurrentThread.ManagedThreadId}.");
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult iftAR = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete), "Main() благодарит вас за сложение этих чисел.");

            // Предположим, что здесь делается какая-то другая работа...
            while (!isDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Работаем...");
            }

            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            Console.WriteLine($"Add() вызывается в потоке {Thread.CurrentThread.ManagedThreadId}.");
            Thread.Sleep(5000);
            return x + y;
        }

        static void AddComplete(IAsyncResult itfAR)
        {
            Console.WriteLine($"AddComplete() вызывается в потоке {Thread.CurrentThread.ManagedThreadId}.");
            Console.WriteLine("Ваше суммирование завершено.");

            // Теперь получить результат.
            AsyncResult ar = (AsyncResult)itfAR;
            BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine($"10 + 10 равно {b.EndInvoke(itfAR)}.");

            // Получить информационный объект и привести его к типу string.
            string msg = (string)itfAR.AsyncState;
            Console.WriteLine(msg);

            isDone = true;
        }
    }
}
