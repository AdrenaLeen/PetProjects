using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterationsAndDecisions
{
    class Program
    {
        static void Main()
        {
            ForLoopExample();
            ForEachLoopExample();
            LinqQueryOverInts();
            WhileLoopExample();
            DoWhileLoopExample();
            IfElseExample();
            Console.ReadLine();
        }

        // Базовый цикл for.
        static void ForLoopExample()
        {
            // Обратите внимание, что переменная i видима только в контексте цикла.
            for (int i = 0; i < 4; i++) Console.WriteLine($"Число равно: {i}");
            // Здесь переменная i больше видимой не будет.
            Console.WriteLine();
        }

        // Проход по элементам массива посредством foreach.
        static void ForEachLoopExample()
        {
            string[] carTypes = { "Ford", "BMW", "Yugo", "Honda" };
            foreach (string c in carTypes) Console.WriteLine(c);

            int[] myInts = { 10, 20, 30, 40 };
            foreach (int i in myInts) Console.WriteLine(i);

            Console.WriteLine();
        }

        static void LinqQueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // Запрос LINQ!
            var subset = from i in numbers where i < 10 select i;
            Console.Write("Значения в subset: ");
            foreach (var i in subset) Console.Write($"{i} ");

            Console.WriteLine();
        }

        static void WhileLoopExample()
        {
            string userIsDone = "";
            // Проверить копию строки в нижнем регистре.
            while (userIsDone.ToLower() != "да")
            {
                Console.WriteLine("В цикле while");
                Console.Write("Вы закончили? [да] [нет]: ");
                userIsDone = Console.ReadLine();
            }

            Console.WriteLine();
        }

        static void DoWhileLoopExample()
        {
            string userIsDone = "";
            do
            {
                Console.WriteLine("В цикле do/while");
                Console.Write("Вы закончили? [да] [нет]: ");
                userIsDone = Console.ReadLine();
            } while (userIsDone.ToLower() != "да"); // Обратите внимание на точку с запятой!

            Console.WriteLine();
        }

        static void IfElseExample()
        {
            // Недопустимо, т.к. свойство Length возвращает int, а не bool.
            string stringData = "Мои текстовые данные";
            // Допустимо, т.к. условие возвращает true или false.
            if (stringData.Length > 0) Console.WriteLine("В строке больше, чем 0 символов.");

            Console.WriteLine();
        }
    }
}
