// Отобразить пользователю простое сообщение.
Console.WriteLine("***** Моё первое C#-приложение *****");
Console.WriteLine("Hello World!");
Console.WriteLine();

// Обработать любые входные аргументы.
for (int i = 0; i < args.Length; i++) Console.WriteLine($"Arg: {args[i]}");

// Обработать любые входные аргументы, используя foreach.
foreach (string arg in args) Console.WriteLine($"Arg: {arg}");

// Получить аргументы с использованием System.Environment.
string[] theArgs = Environment.GetCommandLineArgs();
foreach (string arg in theArgs) Console.WriteLine($"Arg: {arg}");

// Вспомогательный метод внутри класса Program.
ShowEnvironmentDetails();

// Ожидать нажатия клавиши <Enter>, прежде чем завершить работу.
Console.ReadLine();
// Возвратить произвольный код ошибки.
return -1;

static void ShowEnvironmentDetails()
{
    // Вывести информацию о дисковых устройствах данной машины и другие интересные детали.

    // Логические устройства
    foreach (string drive in Environment.GetLogicalDrives()) Console.WriteLine($"Диск: {drive}");

    // Версия операционной системы
    Console.WriteLine($"ОС: {Environment.OSVersion}");

    // Количество процессоров
    Console.WriteLine($"Количество процессоров: {Environment.ProcessorCount}");

    // Версия платформы .NET
    Console.WriteLine($"Версия .NET: {Environment.Version}");
}