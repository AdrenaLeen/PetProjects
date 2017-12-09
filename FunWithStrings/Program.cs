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
            EscapeChars();

            // Следующая строка воспроизводится дословно, так что все управляющие последовательности отображаются.
            Console.WriteLine(@"C:\MyApp\bin\Debug");

            // При использовании дословных строк пробельные символы предохраняются.
            string myLongString = @"Это очень
                 очень
                      очень
                           длинная строка";
            Console.WriteLine(myLongString);
            Console.WriteLine(@"Церебус сказал ""Даррр! Пре-лестные за-каты""");
            Console.WriteLine();

            StringsAreImmutable();

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

        static void EscapeChars()
        {
            Console.WriteLine("=> Управляющие последовательности:\a");
            string strWithTabs = "Модель\tЦвет\tСкорость\tНаименование\a ";
            Console.WriteLine(strWithTabs);

            Console.WriteLine("Все любят \"Hello World\"\a ");
            Console.WriteLine("C:\\MyApp\\bin\\Debug\a ");

            // Добавить 4 пустых строки и снова выдать звуковой сигнал.
            Console.WriteLine("Всё закончено.\n\n\n\a ");
            Console.WriteLine();
        }

        static void StringsAreImmutable()
        {
            // Установить начальное значение для строки.
            string s1 = "Это моя строка.";
            Console.WriteLine("s1 = {0}", s1);

            // Преобразована ли строка s1 в верхний регистр?
            string upperString = s1.ToUpper();
            Console.WriteLine("upperString = {0}", upperString);

            // Нет! Строка s1 осталась в том же виде!
            Console.WriteLine("s1 = {0}", s1);
        }

        static void StringsAreImmutable2()
        {
            string s2 = "Другая моя строка";
            s2 = "Новое строковое значение";
        }
    }
}
