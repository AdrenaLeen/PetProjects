﻿using System;
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
    }
}
