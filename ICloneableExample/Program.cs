using System;
using System.Data.SqlClient;

namespace ICloneableExample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Интерфейсы на первый взгляд *****");

            // Все эти классы поддерживают интерфейс ICloneable.
            string myStr = "Привет";
            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
            SqlConnection sqlCnn = new SqlConnection();

            // Следовательно, все они могут быть переданы методу, принимающему параметр типа ICloneable.
            CloneMe(myStr);
            CloneMe(unixOS);
            CloneMe(sqlCnn);
            Console.ReadLine();
        }

        private static void CloneMe(ICloneable c)
        {
            // Клонировать то, что получено, и вывести его имя.
            object theClone = c.Clone();
            Console.WriteLine($"Ваша копия: {theClone.GetType().Name}");
        }
    }
}
