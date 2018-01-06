using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExpressions
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Лямбда-выражения *****");
            TraditionalDelegateSyntax();
            AnonymousMethodSyntax();
            LambdaExpressionSyntax();

            Console.ReadLine();
        }

        static void TraditionalDelegateSyntax()
        {
            // Создать список целочисленных значений.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Вызвать FindAll() с применением традиционного синтаксиса делегатов.
            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);

            Console.WriteLine("Вот ваши чётные числа:");
            foreach (int evenNumber in evenNumbers) Console.Write($"{evenNumber}\t");
            Console.WriteLine();
        }

        // Цель для делегата Predicate<>.
        static bool IsEvenNumber(int i)
        {
            // Это чётное число?
            return (i % 2) == 0;
        }

        static void AnonymousMethodSyntax()
        {
            // Создать список целочисленных значений.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Теперь использовать анонимный метод.
            List<int> evenNumbers = list.FindAll(delegate (int i)
            { return (i % 2) == 0; });

            Console.WriteLine("Вот ваши чётные числа:");
            foreach (int evenNumber in evenNumbers) Console.Write($"{evenNumber}\t");
            Console.WriteLine();
        }

        static void LambdaExpressionSyntax()
        {
            // Создать список целочисленных значений.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Теперь использовать лямбда-выражение C#.
            List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);

            Console.WriteLine("Вот ваши чётные числа:");
            foreach (int evenNumber in evenNumbers) Console.Write($"{evenNumber}\t");
            Console.WriteLine();
        }
    }
}
