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
            QueryOverStringsLongHand();

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
            ReflectOverQueryResults(subset);

            // Вывести результаты.
            foreach (string s in subset) Console.WriteLine($"Элемент: {s}");
            Console.WriteLine();
        }

        static void QueryOverStringsLongHand()
        {
            // Предположим, что есть массив строк.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            string[] gamesWithSpaces = new string[5];
            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" ")) gamesWithSpaces[i] = currentVideoGames[i];
            }

            // Отсортировать набор.
            Array.Sort(gamesWithSpaces);

            // Вывести результаты.
            foreach (string s in gamesWithSpaces)
            {
                if (s != null) Console.WriteLine($"Элемент: {s}");
            }
            Console.WriteLine();
        }

        static void ReflectOverQueryResults(object resultSet)
        {
            Console.WriteLine("***** Информация о вашем запросе *****");
            Console.WriteLine($"Тип результирующего набора: {resultSet.GetType().Name}");
            Console.WriteLine($"Местоположение результирующего набора: {resultSet.GetType().Assembly.GetName().Name}");
        }
    }
}
