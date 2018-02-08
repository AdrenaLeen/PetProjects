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

            // Вызвать Add() в синхронной манере.
            BinaryOp b = new BinaryOp(Add);

            // Можно было бы также написать b.Invoke(10, 10);
            int answer = b(10, 10);

            // Эти строки кода не завершатся до тех пор, пока не завершится метод Add().
            Console.WriteLine("Делаем больше работы Main()!");
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
