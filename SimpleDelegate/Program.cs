using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            BinaryOp b = new BinaryOp(SimpleMath.Add);

            // Вызвать метод Add() косвенно с использованием объекта делегата.
            // В действительности здесь вызывается метод Invoke()!
            Console.WriteLine($"10 + 10 равно {b(10, 10)}");

            Console.ReadLine();
        }
    }
}
