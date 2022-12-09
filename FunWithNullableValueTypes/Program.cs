// Всё в порядке! Строки являются ссылочными типами.
using FunWithNullableValueTypes;

Console.WriteLine("***** Типы, допускающие null *****");
var dr = new DatabaseReader();

// Получить значение int из "базы данных".
int? i = dr.GetIntFromDatabase();
// Вывод значения переменной i.
if (i.HasValue) Console.WriteLine($"Значение 'i' равно: {i.Value}");
// Значение переменной i не определено.
else Console.WriteLine("Значение 'i' не определено.");

// Получить значение bool из "базы данных".
bool? b = dr.GetBoolFromDatabase();
// Вывод значения переменной b.
if (b != null) Console.WriteLine($"Значение переменной 'b' равно: {b.Value}");
// Значение переменной b не определено.
else Console.WriteLine("Значение 'b' не определено.");

// Если значение, возвращаемое из GetIntFromDataBase(), равно null, то присвоить локальной переменной значение 100.
int myData = dr.GetIntFromDatabase() ?? 100;
Console.WriteLine($"Значение myData: {myData}");

// Более длинный код, в котором не используется синтаксис операции ??.
int? moreData = dr.GetIntFromDatabase();
if (!moreData.HasValue) moreData = 100;
Console.WriteLine($"Значение moreData: {moreData}");

TesterMethod(null);

Console.ReadLine();

static void TesterMethod(string[] args)
{
    // Перед доступом к данным массива мы должны проверить его на равенство null!
    Console.WriteLine($"Вы отправили мне {args?.Length ?? 0} аргументов.");
}