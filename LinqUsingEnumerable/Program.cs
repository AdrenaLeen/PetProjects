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
            QueryStringsWithEnumerableAndLambdas();
            QueryStringsWithEnumerableAndLambdas2();
            QueryStringsWithAnonymousMethods();

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

        static void QueryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine("***** Использование Enumerable / лямбда-выражений *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // Построить выражение запроса с использование расширяющих методов, предоставленных типу Array через тип Enumerable.
            IEnumerable<string> subset = currentVideoGames.Where(game => game.Contains(" ")).OrderBy(game => game).Select(game => game);

            // Вывести результаты.
            foreach (string game in subset) Console.WriteLine($"Элемент: {game}");

            Console.WriteLine();
        }

        static void QueryStringsWithEnumerableAndLambdas2()
        {
            Console.WriteLine("***** Использование Enumerable / лямбда-выражений *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // Разбить на части.
            IEnumerable<string> gamesWithSpaces = currentVideoGames.Where(game => game.Contains(" "));
            IOrderedEnumerable<string> orderedGames = gamesWithSpaces.OrderBy(game => game);
            IEnumerable<string> subset = orderedGames.Select(game => game);

            foreach (string game in subset) Console.WriteLine($"Элемент: {game}");
            Console.WriteLine();
        }

        static void QueryStringsWithAnonymousMethods()
        {
            Console.WriteLine("***** Использование анонимных методов *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // Построить необходимые делегаты Func<> с использованием анонимных методов.
            Func<string, bool> searchFilter = delegate (string game) { return game.Contains(" "); };
            Func<string, string> itemToProcess = delegate (string s) { return s; };

            // Передать делегаты в методы класса Enumerable.
            IEnumerable<string> subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);

            // Вывести результаты.
            foreach (string game in subset) Console.WriteLine($"Элемент: {game}");

            Console.WriteLine();
        }
    }
}
