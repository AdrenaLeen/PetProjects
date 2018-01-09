using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** LINQ to Objects *****");
            QueryOverStrings();

            Console.ReadLine();
        }

        static void QueryOverStrings()
        {
            // Предположим, что есть массив строк.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // Построить выражение запроса для нахождения элементов массива, которые содержат пробелы.
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            // Вывести результаты.
            foreach (string s in subset) Console.WriteLine($"Элемент: {s}");
        }
    }
}
