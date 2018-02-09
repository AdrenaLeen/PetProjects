using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SyncDelegateReview
{
    public delegate int BinaryOp(int x, int y);

    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Обзор вызова делегата в синхронной манере *****");

            // Вывести идентификатор выполняющегося потока.
            Console.WriteLine($"Main() вызывается в потоке {Thread.CurrentThread.ManagedThreadId}.");

            // Вызвать Add() во вторичном потоке.
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);

            // Выполнить другую работу в первичном потоке...
            Console.WriteLine("Делаем больше работы Main()!");

            // По готовности получить результат выполнения метода Add().
            int answer = b.EndInvoke(iftAR);
            Console.WriteLine($"10 + 10 равно {answer}.");
            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            // Вывести идентификатор выполняющегося потока.
            Console.WriteLine($"Add() вызывается в потоке {Thread.CurrentThread.ManagedThreadId}.");

            // Сделать паузу для моделирования длительной операции.
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
