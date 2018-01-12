using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable
{
    class VeryComplexQueryExpression
    {
        public static void QueryStringsWithRawDelegates()
        {
            Console.WriteLine("***** Использование низкоуровневых делегатов *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // Построить необходимые делегаты Func<>.
            Func<string, bool> searchFilter = new Func<string, bool>(Filter);
            Func<string, string> itemToProcess = new Func<string, string>(ProcessItem);

            // Передать делегаты в методы класса Enumerable.
            IEnumerable<string> subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);

            // Вывести результаты.
            foreach (string game in subset) Console.WriteLine($"Элемент: {game}");

            Console.WriteLine();
        }

        // Цели делегатов.
        public static bool Filter(string game) => game.Contains(" ");
        public static string ProcessItem(string game) => game;
    }
}
