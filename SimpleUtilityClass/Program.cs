using System;

namespace SimpleUtilityClass
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Статические классы *****");

            // Это работает нормально.
            TimeUtilClass.PrintDate();
            TimeUtilClass.PrintTime();

            Console.ReadLine();
        }
    }
}
