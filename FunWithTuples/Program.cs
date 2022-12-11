using FunWithTuples;

(string, int, string) values = ("a", 5, "c");
Console.WriteLine($"Первый элемент: {values.Item1}");
Console.WriteLine($"Второй элемент: {values.Item2}");
Console.WriteLine($"Третий элемент: {values.Item3}");
Console.WriteLine();

(string FirstLetter, int TheNumber, string SecondLetter) valuesWithNames = ("a", 5, "c");
(string, int, string) valuesWithNames2 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");
Console.WriteLine($"Первый элемент: {valuesWithNames.FirstLetter}");
Console.WriteLine($"Второй элемент: {valuesWithNames.TheNumber}");
Console.WriteLine($"Третий элемент: {valuesWithNames.SecondLetter}");
Console.WriteLine();

// Система обозначений ItemX по-прежнему работает!
Console.WriteLine($"Первый элемент: {valuesWithNames.Item1}");
Console.WriteLine($"Второй элемент: {valuesWithNames.Item2}");
Console.WriteLine($"Третий элемент: {valuesWithNames.Item3}");
Console.WriteLine();

(int Field1, int Field2) example = (Custom1: 5, Custom2: 7);

Console.WriteLine("=> Вложенные кортежи");
var nt = (5, 4, ("a", "b"));

Console.WriteLine("=> Выведение имен свойств кортежей");
var foo = new { Prop1 = "первый", Prop2 = "второй" };
(string Prop1, string Prop2) bar = (foo.Prop1, foo.Prop2);
Console.WriteLine($"{bar.Prop1};{bar.Prop2}");
Console.WriteLine();

Console.WriteLine("=> Эквивалентность/неэквивалентность кортежей");
// Поднятые преобразования
var left = (a: 5, b: 10);
(int? a, int? b) nullableMembers = (5, 10);
// Тоже True
Console.WriteLine(left == nullableMembers);
// Преобразованным типом слева является (long, long)
(long a, long b) longTuple = (5, 10);
// Тоже True
Console.WriteLine(left == longTuple);
// Преобразования выполняются с кортежами (long, long)
(long a, int b) longFirst = (5, 10);
(int a, long b) longSecond = (5, 10);
// Тоже True
Console.WriteLine(longFirst == longSecond);

(int a, string b, bool c) samples = FillTheseValues();
Console.WriteLine($"Int: {samples.a}");
Console.WriteLine($"String: {samples.b}");
Console.WriteLine($"Boolean: {samples.c}");
Console.WriteLine();

var (first, _, last) = SplitNames("Ксения Сергеевна Кузнецова");
Console.WriteLine($"{first} {last}");
Console.WriteLine();

Console.WriteLine(RockPaperScissors(("бумага", "камень")));

var p = new Point(7, 5);
(int XPos, int YPos) = p;
Console.WriteLine($"X: {XPos}");
Console.WriteLine($"Y: {YPos}");
Console.WriteLine(GetQuadrant(p));

Console.ReadLine();

static (int a, string b, bool c) FillTheseValues() => (9, "Насладитесь этой строкой.", true);

// Действия, необходимые для расщепления полного имени.
static (string first, string middle, string last) SplitNames(string fullName) => ("Ксения", "Сергеевна", "Кузнецова");

static string RockPaperScissors((string first, string second) value)
{
    return value switch
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

static string GetQuadrant(Point p)
{
    return p switch
    {
        (0, 0) => "Начало",
        var (x, y) when x > 0 && y > 0 => "Один",
        var (x, y) when x < 0 && y > 0 => "Два",
        var (x, y) when x < 0 && y < 0 => "Три",
        var (x, y) when x > 0 && y < 0 => "Четыре",
        var (_, _) => "Граница"
    };
}