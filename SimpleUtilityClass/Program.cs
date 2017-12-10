using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
