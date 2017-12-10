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
    }
}
