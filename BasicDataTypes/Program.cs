﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataTypes
{
    class Program
    {
        static void Main()
        {
            LocalVarDeclarations();
            NewingDataTypes();
            Console.ReadLine();
        }

        private static void LocalVarDeclarations()
        {
            Console.WriteLine("=> Объявление переменных:");
            // Локальные переменные объявляются и инициализируются так:
            // типДанных имяПеременной = начальноеЗначение;
            int myInt = 0;

            // Объявлять и присваивать можно также в двух отдельных строках.
            string myString;
            myString = "Это мои символьные данные";

            // Объявить три переменные типа bool в одной строке.
            bool b1 = true, b2 = false, b3 = b1;

            // Использовать тип данных System.Boolean для объявления булевской переменной.
            System.Boolean b4 = false;

            Console.WriteLine("Ваши данные: {0}, {1}, {2}, {3}, {4}, {5}", myInt, myString, b1, b2, b3, b4);
            Console.WriteLine();
        }

        private static void NewingDataTypes()
        {
            Console.WriteLine("=> Использование new для создания переменных:");
            // Устанавливается в false.
            bool b = new bool();

            // Устанавливается в 0.
            int i = new int();

            // Устанавливается в 0.
            double d = new double();

            // Устанавливается в 1/1/0001 12:00:00 AM.
            DateTime dt = new DateTime();

            Console.WriteLine("{0}, {1}, {2}, {3}", b, i, d, dt);
            Console.WriteLine();
        }
    }
}
