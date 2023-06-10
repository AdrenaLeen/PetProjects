Console.WriteLine("***** LINQ to Objects *****");
QueryOverStrings();
QueryOverStringsWithExtensionMethods();
QueryOverStringsLongHand();
QueryOverInts();
ImmediateExecution();

Console.ReadLine();

static void QueryOverStrings()
{
    // Предположим, что есть массив строк.
    string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

    // Построить выражение запроса для нахождения элементов массива, которые содержат пробелы.
    IEnumerable<string> subset = from g in currentVideoGames
                                 where g.Contains(' ')
                                 orderby g
                                 select g;
    ReflectOverQueryResults(subset);
    Console.WriteLine();

    // Вывести результаты.
    foreach (string s in subset) Console.WriteLine($"Элемент: {s}");
}

static void QueryOverStringsWithExtensionMethods()
{
    // Пусть имеется массив строк.
    string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

    // Построить выражение запроса для поиска в массиве элементов, которые содержат пробелы.
    IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(' ')).OrderBy(g => g).Select(g => g);
    IEnumerable<string> subset2 = currentVideoGames.Where(g => g.Contains(' ')).OrderBy(g => g);

    ReflectOverQueryResults(subset, "расширяющих методов");
    ReflectOverQueryResults(subset2, "расширяющих методов");
    Console.WriteLine();

    // Вывести результаты.
    foreach (string s in subset) Console.WriteLine($"Элемент: {s}");
}

static void QueryOverStringsLongHand()
{
    // Предположим, что есть массив строк.
    string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

    string[] gamesWithSpaces = new string[5];
    for (int i = 0; i < currentVideoGames.Length; i++)
    {
        if (currentVideoGames[i].Contains(' ')) gamesWithSpaces[i] = currentVideoGames[i];
    }

    // Отсортировать набор.
    Array.Sort(gamesWithSpaces);
    Console.WriteLine();

    // Вывести результаты.
    foreach (string s in gamesWithSpaces)
    {
        if (s != null) Console.WriteLine($"Элемент: {s}");
    }
    Console.WriteLine();
}

static void ReflectOverQueryResults(object resultSet, string queryType = "выражений запросов")
{
    Console.WriteLine();
    Console.WriteLine($"***** Информация о вашем запросе с использованием {queryType}*****");
    Console.WriteLine($"Тип результирующего набора: {resultSet.GetType().Name}");
    Console.WriteLine($"Местоположение результирующего набора: {resultSet.GetType().Assembly.GetName().Name}");
}

static void QueryOverInts()
{
    int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

    // Вывести только элементы меньше 10.
    var subset = from i in numbers where i < 10 select i;
    
    // Оператор LINQ здесь оценивается!
    foreach (var i in subset) Console.WriteLine($"{i} < 10");
    Console.WriteLine();

    // Изменить некоторые данные в массиве.
    numbers[0] = 4;

    // Снова производится оценка!
    foreach (var j in subset) Console.WriteLine($"{j} < 10");
    ReflectOverQueryResults(subset);
}

static void ImmediateExecution()
{
    Console.WriteLine();
    Console.WriteLine("Немедленное выполнение");
    int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

    // Получить первый элемент в порядке последовательности.
    int number = (from i in numbers select i).First();
    Console.WriteLine($"Первый элемент: {number}");

    // Получить первый элемент в порядке запроса.
    number = (from i in numbers orderby i select i).First();
    Console.WriteLine($"Первый элемент: {number}");

    // Получить один элемент, который соответствует запросу.
    number = (from i in numbers where i > 30 select i).Single();
    Console.WriteLine($"Единственный элемент: {number}");

    try
    {
        // В случае возвращения более одного элемента генерируется исключение.
        number = (from i in numbers where i > 10 select i).Single();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Возникло исключение: {ex.Message}");
    }

    // Получить данные НЕМЕДЛЕННО как int[].
    int[] subsetAsIntArray = (from i in numbers where i < 10 select i).ToArray<int>();

    // Получить данные НЕМЕДЛЕННО как List<int>.
    var subsetAsListOfInts = (from i in numbers where i < 10 select i).ToList<int>();
}