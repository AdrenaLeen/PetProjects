using LambdaExpressions;

Console.WriteLine("***** Лямбда-выражения *****");
TraditionalDelegateSyntax();
AnonymousMethodSyntax();
LambdaExpressionSyntax();

// Зарегистрировать делегат как лямбда-выражение.
var m = new SimpleMath();
m.SetMathHandler((msg, result) =>
{
    Console.WriteLine($"Сообщение: {msg}, Результат: {result}");
});

// Это приведёт к выполнению лямбда-выражения.
m.Add(10, 10);

var d = new VerySimpleDelegate(() =>
{
    return "Наслаждайтесь свой строкой!";
});
Console.WriteLine(d());

var d2 = new VerySimpleDelegate(() => "Наслаждайтесь свой строкой!");
Console.WriteLine(d2());

VerySimpleDelegate d3 = () => "Наслаждайтесь свой строкой!";
Console.WriteLine(d3());

var outerVariable = 0;

Func<int, int, bool> DoWork = static (x, y) =>
{
    return true;
};
DoWork(3, 4);
Console.WriteLine($"Внешняя переменная сейчас = {outerVariable}");

Console.ReadLine();

static void TraditionalDelegateSyntax()
{
    // Создать список целочисленных значений.
    var list = new List<int>();
    list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

    // Вызвать FindAll() с применением традиционного синтаксиса делегатов.
    Predicate<int> callback = IsEvenNumber;
    List<int> evenNumbers = list.FindAll(callback);

    Console.WriteLine("Вот ваши четные числа:");
    foreach (int evenNumber in evenNumbers) Console.Write($"{evenNumber}\t");
    Console.WriteLine();
}

// Цель для делегата Predicate<>.
// Это четное число?
static bool IsEvenNumber(int i) => (i % 2) == 0;

static void AnonymousMethodSyntax()
{
    // Создать список целочисленных значений.
    var list = new List<int>();
    list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

    // Теперь использовать анонимный метод.
    List<int> evenNumbers = list.FindAll(delegate (int i)
    {
        return (i % 2) == 0;
    });

    Console.WriteLine("Вот ваши четные числа:");
    foreach (int evenNumber in evenNumbers) Console.Write($"{evenNumber}\t");
    Console.WriteLine();
}

static void LambdaExpressionSyntax()
{
    // Создать список целочисленных значений.
    var list = new List<int>();
    list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

    // Обработать каждый аргумент внутри группы операторов кода.
    List<int> evenNumbers = list.FindAll((i) =>
    {
        Console.WriteLine($"Текущее значение i: {i}");
        return (i % 2) == 0;
    });

    Console.WriteLine("Вот ваши четные числа:");
    foreach (int evenNumber in evenNumbers) Console.Write($"{evenNumber}\t");
    Console.WriteLine();
}