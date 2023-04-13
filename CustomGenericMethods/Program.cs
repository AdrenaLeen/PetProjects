using CustomGenericMethods;

Console.WriteLine("***** Специальные обобщённые методы *****");

// Обмен двух целочисленных значений.
int a = 10, b = 90;
Console.WriteLine($"До обмена: {a}, {b}");
SwapFunctions.Swap<int>(ref a, ref b);
Console.WriteLine($"После обмена: {a}, {b}");
Console.WriteLine();

// Обмен двух строковых значений.
string s1 = "Привет", s2 = "Всем";
Console.WriteLine($"До обмена: {s1} {s2}");
SwapFunctions.Swap(ref s1, ref s2);
Console.WriteLine($"После обмена: {s1} {s2}");
Console.WriteLine();

// Компилятор выведет тип System.Boolean.
bool b1 = true, b2 = false;
Console.WriteLine($"До обмена: {b1}, {b2}");
SwapFunctions.Swap(ref b1, ref b2);
Console.WriteLine($"После обмена: {b1}, {b2}");
Console.WriteLine();

// Если метод не принимает параметров, то должно быть указан параметр типа.
DisplayBaseClass<int>();
DisplayBaseClass<string>();

Console.ReadLine();

// BaseType - это метод, используемый в рефлексии.
static void DisplayBaseClass<T>() => Console.WriteLine($"Базовый класс {typeof(T)}: {typeof(T).BaseType}.");