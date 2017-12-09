using System;
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
    }
}
