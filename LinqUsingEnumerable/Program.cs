using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable
{
    class Program
    {
        static void Main()
        {
            QueryStringWithOperators();

            Console.ReadLine();
        }

        static void QueryStringWithOperators()
        {
            Console.WriteLine("***** Использование операций запросов *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};
            IOrderedEnumerable<string> subset = from game in currentVideoGames
                         where game.Contains(" ")
                         orderby game
                         select game;
            foreach (string s in subset) Console.WriteLine($"Элемент: {s}");
            Console.WriteLine();
        }
    }
}
