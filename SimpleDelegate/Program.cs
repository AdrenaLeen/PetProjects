using System;

namespace SimpleDelegate
{
    class Program
    {
        // Этот делегат может указывать на любой метод, который принимает два целочисленных значения и возвращает целое значение.
        public delegate int BinaryOp(int x, int y);

        static void Main()
        {
            Console.WriteLine("***** Пример простейшего делегата *****");

            // Создать объект делегата BinaryOp, который "указывает" на SimpleMath.Add().
            // Делегаты .NET могут также указывать на методы экземпляра.
            SimpleMath m = new SimpleMath();
            BinaryOp b = new BinaryOp(m.Add);

            // Вывести сведения об объекте.
            DisplayDelegateInfo(b);

            // Вызвать метод Add() косвенно с использованием объекта делегата.
            // В действительности здесь вызывается метод Invoke()!
            Console.WriteLine($"10 + 10 равно {b(10, 10)}");

            Console.ReadLine();
        }

        static void DisplayDelegateInfo(Delegate delObj)
        {
            // Вывести имена всех членов в списке вызовов делегата.
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine($"Название метода: {d.Method}");
                Console.WriteLine($"Название типа: {d.Target}");
            }
        }
    }
}
