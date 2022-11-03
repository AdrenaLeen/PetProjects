ForLoopExample();
ForEachLoopExample();
LinqQueryOverInts();
WhileLoopExample();
DoWhileLoopExample();
IfElseExample();
IfElsePatternMatching();
IfElsePatternMatchingUpdated();
ExecuteIfElseUsingConditionalOperator();
ConditionalRefExample();
SwitchExample();
SwitchOnStringExample();
SwitchOnEnumExample();
ExecutePatternMatchingSwitch();
ExecutePatternMatchingSwitchWithWhen();
FromRainbowClassic("Red");
FromRainbow("Orange");
Console.WriteLine(RockPaperScissors("бумага", "камень"));
Console.WriteLine(RockPaperScissors("ножницы", "камень"));
Console.ReadLine();

// Базовый цикл for.
static void ForLoopExample()
{
    // Обратите внимание, что переменная i видима только в контексте цикла.
    for (int i = 0; i < 4; i++) Console.WriteLine($"Число равно: {i}");
    // Здесь переменная i больше видимой не будет.
    Console.WriteLine();
}

// Проход по элементам массива посредством foreach.
static void ForEachLoopExample()
{
    string[] carTypes = { "Ford", "BMW", "Yugo", "Honda" };
    foreach (string c in carTypes) Console.WriteLine(c);

    int[] myInts = { 10, 20, 30, 40 };
    foreach (int i in myInts) Console.WriteLine(i);

    Console.WriteLine();
}

static void LinqQueryOverInts()
{
    int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
    // Запрос LINQ!
    var subset = from i in numbers where i < 10 select i;
    Console.Write("Значения в subset: ");
    foreach (var i in subset) Console.Write($"{i} ");

    Console.WriteLine();
}

static void WhileLoopExample()
{
    string? userIsDone = "";
    // Проверить копию строки в нижнем регистре.
    while (userIsDone?.ToLower() != "да")
    {
        Console.WriteLine("В цикле while");
        Console.Write("Вы закончили? [да] [нет]: ");
        userIsDone = Console.ReadLine();
    }

    Console.WriteLine();
}

static void DoWhileLoopExample()
{
    string? userIsDone = "";
    do
    {
        Console.WriteLine("В цикле do/while");
        Console.Write("Вы закончили? [да] [нет]: ");
        userIsDone = Console.ReadLine();
    } while (userIsDone?.ToLower() != "да"); // Обратите внимание на точку с запятой!

    Console.WriteLine();
}

static void IfElseExample()
{
    // Недопустимо, т.к. свойство Length возвращает int, а не bool.
    var stringData = "Мои текстовые данные";
    // Допустимо, т.к. условие возвращает true или false.
    if (stringData.Length > 0) Console.WriteLine("В строке больше, чем 0 символов.");

    Console.WriteLine();
}

static void IfElsePatternMatching()
{
    object testItem1 = 123;
    object testItem2 = "Hello";
    if (testItem1 is string myStringValue1) Console.WriteLine($"{myStringValue1} имеет тип string");
    if (testItem1 is int myValue1) Console.WriteLine($"{myValue1} имеет тип int");
    if (testItem2 is string myStringValue2) Console.WriteLine($"{myStringValue2} имеет тип string");
    if (testItem2 is int myValue2) Console.WriteLine($"{myValue2} имеет тип int");

    Console.WriteLine();
}

static void IfElsePatternMatchingUpdated()
{
    object testItem1 = 123;
    Type t = typeof(string);
    char c = 'f';

    // Образцы типов
    if (t is Type) Console.WriteLine($"{t} является Type");

    // Относительные, конъюнктивные и дизъюнктивные образцы
    if (c is >= 'a' and <= 'z' or >= 'A' and <= 'Z') Console.WriteLine($"{c} является символом");

    // Образцы в круглых скобках
    if (c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',') Console.WriteLine($"{c} является символом или разделителем");

    // Инвертированные образцы
    if (testItem1 is not string) Console.WriteLine($"{testItem1} не является строкой");
    if (testItem1 is not null) Console.WriteLine($"{testItem1} не является null");
    
    Console.WriteLine();
}

static void ExecuteIfElseUsingConditionalOperator()
{
    string stringData = "Мои текстовые данные";
    Console.WriteLine(stringData.Length > 0
        ? "строка длиннее 0 символов"
        : "строка не длиннее 0 символов");
    Console.WriteLine();
}

static void ConditionalRefExample()
{
    var smallArray = new int[] { 1, 2, 3, 4, 5 };
    var largeArray = new int[] { 10, 20, 30, 40, 50 };

    int index = 7;
    ref int refValue = ref ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]);
    refValue = 0;

    index = 2;
    ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]) = 100;

    Console.WriteLine(string.Join(" ", smallArray));
    Console.WriteLine(string.Join(" ", largeArray));
    Console.WriteLine();
}

// Переключение на основе числового значения
static void SwitchExample()
{
    Console.WriteLine("1 [C#], 2 [VB]");
    Console.Write("Выберите предпочитаемый язык: ");

    string? langChoice = Console.ReadLine();
    int n = langChoice == null ? default : int.Parse(langChoice);

    switch (n)
    {
        case 1:
            Console.WriteLine("Хороший выбор. C# - замечательный язык.");
            break;
        case 2:
            Console.WriteLine("VB: ООП, многопоточность и многое другое!");
            break;
        default:
            Console.WriteLine("Хорошо, удачи с этим!");
            break;
    }

    Console.WriteLine();
}

static void SwitchOnStringExample()
{
    Console.WriteLine("C# или VB");
    Console.Write("Пожалуйста, выберите предпочитаемый язык: ");

    string? langChoice = Console.ReadLine();
    switch (langChoice)
    {
        case "C#":
            Console.WriteLine("Хороший выбор. C# - замечательный язык.");
            break;
        case "VB":
            Console.WriteLine("VB: ООП, многопоточность и многое другое!");
            break;
        default:
            Console.WriteLine("Хорошо, удачи с этим!");
            break;
    }

    Console.WriteLine();
}

static void SwitchOnEnumExample()
{
    Console.Write("Введите любимый день недели: ");
    DayOfWeek favDay;

    try
    {
        favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Console.ReadLine());
    }
    catch (Exception)
    {
        Console.WriteLine("Недопустимое входное значение!");
        return;
    }

    switch (favDay)
    {
        case DayOfWeek.Friday:
            Console.WriteLine("Да, пятница рулит!");
            break;
        case DayOfWeek.Monday:
            Console.WriteLine("Ещё один день, ещё один доллар.");
            break;
        case DayOfWeek.Saturday:
            Console.WriteLine("Действительно великолепный день.");
            break;
        case DayOfWeek.Sunday:
            Console.WriteLine("Футбол!");
            break;
        case DayOfWeek.Thursday:
            Console.WriteLine("Почти пятница...");
            break;
        case DayOfWeek.Tuesday:
            Console.WriteLine("Во всяком случае, не понедельник.");
            break;
        case DayOfWeek.Wednesday:
            Console.WriteLine("Хороший денёк.");
            break;
    }

    Console.WriteLine();
}

static void ExecutePatternMatchingSwitch()
{
    Console.WriteLine("1 [Целое число (5)], 2 [Строка (\"Привет\")], 3 [Десятичное число (2.5)]");
    Console.Write("Пожалуйста, выберете вариант: ");
    string? userChoice = Console.ReadLine();
    object choice;

    // Стандартный оператор switch, в котором применяется сопоставление с образцом с константами
    switch (userChoice)
    {
        case "1":
            choice = 5;
            break;
        case "2":
            choice = "Привет";
            break;
        case "3":
            choice = 2.5m;
            break;
        default:
            choice = 5;
            break;
    }

    // Новый оператор switch, в котором применяется сопоставление с образцом с типами
    switch (choice)
    {
        case int i:
            Console.WriteLine($"Выбрано целое число {i}.");
            break;
        case string s:
            Console.WriteLine($"Выбрана строка {s}");
            break;
        case decimal d:
            Console.WriteLine($"Выбрано десятичное число {d}.");
            break;
        default:
            Console.WriteLine("Выбрано что-то другое.");
            break;
    }
    Console.WriteLine();
}

static void ExecutePatternMatchingSwitchWithWhen()
{
    Console.WriteLine("1 [C#], 2 [VB]");
    Console.Write("Пожалуйста, выберите предпочитаемый язык: ");
    object? langChoice = Console.ReadLine();
    object? choice = int.TryParse(langChoice?.ToString(), out int c) ? c : langChoice;
    switch (choice)
    {
        case int i when i == 2:
        case string s when s.Equals("VB", StringComparison.OrdinalIgnoreCase):
            Console.WriteLine("VB: ООП, многопоточность и многое другое!");
            break;
        case int i when i == 1:
        case string s when s.Equals("C#", StringComparison.OrdinalIgnoreCase):
            Console.WriteLine("Хороший выбор. C# - замечательный язык.");
            break;
        default:
            Console.WriteLine("Хорошо, удачи с этим!");
            break;
    }
    Console.WriteLine();
}

static string FromRainbowClassic(string colorBand)
{
    switch (colorBand)
    {
        case "Red":
            return "#FF0000";
        case "Orange":
            return "#FF7F00";
        case "Yellow":
            return "#FFFF00";
        case "Green":
            return "#00FF00";
        case "Blue":
            return "#0000FF";
        case "Indigo":
            return "#4B0082";
        case "Violet":
            return "#9400D3";
        default:
            return "#FFFFFF";
    };
}

static string FromRainbow(string colorBand)
{
    return colorBand switch
    {
        "Red" => "#FF0000",
        "Orange" => "#FF7F00",
        "Yellow" => "#FFFF00",
        "Green" => "#00FF00",
        "Blue" => "#0000FF",
        "Indigo" => "#4B0082",
        "Violet" => "#9400D3",
        _ => "#FFFFFF",
    };
}

// Выражения switch с кортежами
static string RockPaperScissors(string first, string second)
{
    return (first, second) switch
    {
        ("камень", "бумага") => "Камень накрывается бумагой. Бумага побеждает.",
        ("камень", "ножницы") => "Камень ломает ножницы. Камень побеждает.",
        ("бумага", "камень") => "Бумага накрывает камень. Бумага побеждает.",
        ("бумага", "ножницы") => "Бумага разрезается ножницами. Ножницы побеждают.",
        ("ножницы", "камень") => "Ножницы сломаны камнем. Камень побеждает.",
        ("ножницы", "бумага") => "Ножницы разрезают бумагу. Ножницы побеждают.",
        (_, _) => "Ничья.",
    };
}