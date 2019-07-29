using System;

namespace FunWithLocalFunctions
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Локальные функции");

            // Вызвать оригинальную версию Add().
            Console.WriteLine(Add(10, 10));

            // Вызвать обновлённую версию Add().
            Console.WriteLine(AddWrapper(10, 10));
            Console.ReadLine();
        }

        // Выполнить здесь проверку достоверности.
        static int Add(int x, int y) => x + y;

        static int AddWrapper(int x, int y)
        {
            // Выполнить здесь проверку достоверности.
            return Add();
            int Add() => x + y;
        }
    }
}
