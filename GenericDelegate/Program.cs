using GenericDelegate;

Console.WriteLine("***** Обобщённые делегаты *****");

// Зарегистрировать цели.
var strTarget = new MyGenericDelegate<string>(StringTarget);
strTarget("Некоторые строковые данные");

// Использовать синтаксис группового преобразования методов.
MyGenericDelegate<int> intTarget = IntTarget;
intTarget(9);
Console.ReadLine();

static void StringTarget(string arg) => Console.WriteLine($"arg в верхнем регистре: {arg.ToUpper()}");

static void IntTarget(int arg) => Console.WriteLine($"++arg: {++arg}");