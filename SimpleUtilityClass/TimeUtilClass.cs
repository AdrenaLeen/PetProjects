using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.DateTime;

namespace SimpleUtilityClass
{
    // Статические классы могут содержать только статические члены!
    static class TimeUtilClass
    {
        public static void PrintTime()
        {
            WriteLine(Now.ToShortTimeString());
        }

        public static void PrintDate()
        {
            WriteLine(Today.ToShortDateString());
        }
    }
}
