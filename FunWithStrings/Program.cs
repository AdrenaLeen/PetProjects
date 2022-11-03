using System.Text;

BasicStringFunctionality();
StringConcatenation();
StringInterpolation();
EscapeChars();
VerbatimStrings();
StringEquality();
StringEqualitySpecifyingCompareRules();
StringsAreImmutable();
StringsAreImmutable2();
FunWithStringBuilder();

Console.ReadLine();

static void BasicStringFunctionality()
{
    Console.WriteLine("=> Базовая функциональность строк:");
    string firstName = "Фредди";

    // Значение firstName.
    Console.WriteLine($"Значение firstName: {firstName}");

    // Длина firstName.
    Console.WriteLine($"firstName содержит {firstName.Length} букв.");

    // firstName в верхнем регистре.
    Console.WriteLine($"firstName в верхнем регистре: {firstName.ToUpper()}");

    // firstName в нижнем регистре.
    Console.WriteLine($"firstName в нижнем регистре: {firstName.ToLower()}");

    // Содержит ли firstName букву и?
    Console.WriteLine($"firstName содержит букву и?: {firstName.Contains("и")}");

    // firstName после замены.
    Console.WriteLine($"Новое имя: {firstName.Replace("ди", "")}");
    Console.WriteLine();
}

static void StringConcatenation()
{
    Console.WriteLine("=> Конкатенация строк:");
    string s1 = "Programming the ";
    string s2 = "PsychoDrill (PTP)";
    string s3 = String.Concat(s1, s2);
    Console.WriteLine(s3);
    Console.WriteLine();
}

static void EscapeChars()
{
    Console.WriteLine("=> Управляющие последовательности:\a");
    string strWithTabs = "Модель\tЦвет\tСкорость\tНаименование\a ";
    Console.WriteLine(strWithTabs);

    Console.WriteLine("Все любят \"Hello World\"\a ");
    Console.WriteLine("C:\\MyApp\\bin\\Debug\a ");

    // Добавить 4 пустых строки и снова выдать звуковой сигнал.
    Console.WriteLine("Всё закончено.\n\n\n\a ");
    Console.WriteLine();
}

static void StringsAreImmutable()
{
    // Установить начальное значение для строки.
    string s1 = "Это моя строка.";
    Console.WriteLine($"s1 = {s1}");

    // Преобразована ли строка s1 в верхний регистр?
    string upperString = s1.ToUpper();
    Console.WriteLine($"upperString = {upperString}");

    // Нет! Строка s1 осталась в том же виде!
    Console.WriteLine($"s1 = {s1}");
}

static void StringsAreImmutable2()
{
    string s2 = "Другая моя строка";
    s2 = "Новое строковое значение";
}

static void FunWithStringBuilder()
{
    Console.WriteLine("=> Использование StringBuilder:");
    // Создать экземпляр StringBuilder с исходным размером в 256 символов
    StringBuilder sb = new StringBuilder("**** Фантастические игры ****", 256);
    sb.Append("\n");
    sb.AppendLine("Half Life");
    sb.AppendLine("Beyond Good and Evil");
    sb.AppendLine("Deus Ex 2");
    sb.AppendLine("System Shock");
    Console.WriteLine(sb.ToString());
    sb.Replace("2", "Invisible War");
    Console.WriteLine(sb.ToString());
    Console.WriteLine($"sb содержит {sb.Length} символов.");
    Console.WriteLine();
}

static void StringInterpolation()
{
    // Некоторые локальные переменные будут включены в крупную строку.
    int age = 4;
    string name = "Сорен";

    // Использование синтаксиса с фигурными скобками
    string greeting = string.Format("\tЗдравствуйте, {0}, вам {1} года.", name.ToUpper(), age);
    Console.WriteLine(greeting);

    // Использование интерполяции строк
    string greeting2 = $"\tЗдравствуйте, {name.ToUpper()}, вам {age} года.";
    Console.WriteLine(greeting2);
}

static void VerbatimStrings()
{
    Console.WriteLine("=> Дословные строки:");

    // Следующая строка воспроизводится дословно, так что все управляющие последовательности отображаются.
    Console.WriteLine(@"C:\MyApp\bin\Debug");

    // При использовании дословных строк пробельные символы предохраняются.
    string myLongString = @"Это очень
                 очень
                      очень
                           длинная строка";
    Console.WriteLine(myLongString);
    Console.WriteLine(@"Церебус сказал ""Даррр! Пре-лестные за-каты""");
    string interp = "интерполяция";
    string myLongString2 = $@"Это очень
            очень
                длинная строка с {interp}";
    Console.WriteLine(myLongString2);
    string myLongString3 = @$"Это очень
            очень
                длинная строка с {interp}";
    Console.WriteLine(myLongString3);
    Console.WriteLine();
}

static void StringEquality()
{
    Console.WriteLine("=> Равенство строк:");
    string s1 = "Привет!";
    string s2 = "Йо!";
    Console.WriteLine($"s1 = {s1}");
    Console.WriteLine($"s2 = {s2}");
    Console.WriteLine();

    // Проверить строки на равенство.
    Console.WriteLine($"s1 == s2: {s1 == s2}");
    Console.WriteLine($"s1 == Привет!: {s1 == "Привет!"}");
    Console.WriteLine($"s1 == ПРИВЕТ!: {s1 == "ПРИВЕТ!"}");
    Console.WriteLine($"s1 == привет!: {s1 == "привет!"}");
    Console.WriteLine($"s1.Equals(s2): {s1.Equals(s2)}");
    Console.WriteLine($"Йо.Equals(s2): {"Йо!".Equals(s2)}");
    Console.WriteLine();
}

static void StringEqualitySpecifyingCompareRules()
{
    Console.WriteLine("=> Равенство строк (без учета регистра):");
    string s1 = "Привет!";
    string s2 = "ПРИВЕТ!";
    Console.WriteLine($"s1 = {s1}");
    Console.WriteLine($"s2 = {s2}");
    Console.WriteLine();

    // Проверить результаты изменения стандартных правил сравнения.
    Console.WriteLine($"Стандартные правила: s1={s1}, s2={s2}, s1.Equals(s2): {s1.Equals(s2)}");
    Console.WriteLine($"Без учета регистра: s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {s1.Equals(s2, StringComparison.OrdinalIgnoreCase)}");
    Console.WriteLine($"Без учета регистра, инвариантная культура: s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase)}");
    Console.WriteLine();
    Console.WriteLine($"Стандартные правила: s1={s1}, s2={s2}, s1.IndexOf(\"Е\"): {s1.IndexOf("Е")}");
    Console.WriteLine($"Без учета регистра: s1.IndexOf(\"Е\", StringComparison.OrdinalIgnoreCase): {s1.IndexOf("Е", StringComparison.OrdinalIgnoreCase)}");
    Console.WriteLine($"Без учета регистра, инвариантная культура: s1.IndexOf(\"Е\", StringComparison.InvariantCultureIgnoreCase): {s1.IndexOf("Е", StringComparison.InvariantCultureIgnoreCase)}");
    Console.WriteLine();
}