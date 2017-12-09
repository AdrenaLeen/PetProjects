using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithStrings
{
    class Program
    {
        static void Main()
        {
            BasicStringFunctionality();
            StringConcatenation();
            Console.ReadLine();
        }

        static void BasicStringFunctionality()
        {
            Console.WriteLine("=> Базовая функциональность строк:");
            string firstName = "Фредди";

            // Значение firstName.
            Console.WriteLine("Значение firstName: {0}", firstName);

            // Длина firstName.
            Console.WriteLine("firstName содержит {0} букв.", firstName.Length);

            // firstName в верхнем регистре.
            Console.WriteLine("firstName в верхнем регистре: {0}", firstName.ToUpper());

            // firstName в нижнем регистре.
            Console.WriteLine("firstName в нижнем регистре: {0}", firstName.ToLower());

            // Содержит ли firstName букву и?
            Console.WriteLine("firstName содержит букву и?: {0}", firstName.Contains("и"));

            // firstName после замены.
            Console.WriteLine("Новое имя: {0}", firstName.Replace("ди", ""));
            Console.WriteLine();
        }

        static void StringConcatenation()
        {
            Console.WriteLine("=> Конкатенация строк:");
            string s1 = "Programming the ";
            string s2 = "PsychoDrill (PTP)";
            string s3 = String.Concat(s1, s2);
            Console.WriteLine(s3);
            Console.WriteLine();
        }
    }
}
