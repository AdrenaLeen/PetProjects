using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithArrays
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Массивы *****");
            SimpleArrays();
            ArrayInitialization();
            DeclareImplicitArrays();
            Console.ReadLine();
        }

        static void SimpleArrays()
        {
            Console.WriteLine("=> Создание простого массива.");
            // Создать массив int, который содержит 3 элемента с индексами 0, 1, 2.
            int[] myInts = new int[3];

            // Создать массив string, который содержит 100 элементов с индексами 0 - 99.
            string[] booksOnDotNet = new string[100];

            myInts[0] = 100;
            myInts[1] = 200;
            myInts[2] = 300;

            // Вывести все значения.
            foreach (int i in myInts) Console.WriteLine(i);
            Console.WriteLine();
        }

        static void ArrayInitialization()
        {
            Console.WriteLine("=> Инициализация массивов.");

            // Синтаксис инициализации массива с использованием ключевого слова new.
            string[] stringArray = new string[] { "один", "два", "три" };
            Console.WriteLine($"stringArray содержит {stringArray.Length} элемента");

            // Синтаксис инициализации массива без использования ключевого слова new.
            bool[] boolArray = { false, false, true };
            Console.WriteLine($"boolArray содержит {boolArray.Length} элемента");

            // Инициализация массива с применением ключевого слова new и указанием размера.
            int[] intArray = new int[4] { 20, 22, 23, 0 };
            Console.WriteLine($"intArray содержит {intArray.Length} элемента");
            Console.WriteLine();
        }

        static void DeclareImplicitArrays()
        {
            Console.WriteLine("=> Неявная инициализация массивов.");

            // Переменная a на самом деле имеет тип int[].
            var a = new[] { 1, 10, 100, 1000 };
            Console.WriteLine("a является: {0}", a.ToString());

            // Переменная b на самом деле имеет тип double[].
            var b = new[] { 1, 1.5, 2, 2.5 };
            Console.WriteLine("b является: {0}", b.ToString());

            // Переменная c на самом деле имеет тип string[].
            var c = new[] { "hello", null, "world" };
            Console.WriteLine("c является: {0}", c.ToString());
            Console.WriteLine();
        }
    }
}
