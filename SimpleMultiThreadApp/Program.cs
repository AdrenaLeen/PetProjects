using SimpleMultiThreadApp;

Console.WriteLine("***** Потоки *****");
Console.Write("Вы хотите [1] или [2] потока? ");
string threadCount = Console.ReadLine() ?? "1";

// Назначить имя текущему потоку.
Thread primaryThread = Thread.CurrentThread;
primaryThread.Name = "Primary";

// Вывести информацию о потоке.
Console.WriteLine($"-> {Thread.CurrentThread.Name} выполняет Main()");

switch (threadCount)
{
    case "2":
        // Создать поток.
        var backgroundThread = new Thread(new ThreadStart(Printer.PrintNumbers)) { Name = "Secondary" };
        backgroundThread.Start();
        break;
    case "1":
        Printer.PrintNumbers();
        break;
    default:
        Console.WriteLine("Я не знаю, чего вы хотите... Вы получаете 1 поток.");
        // Переход к варианту с одним потоком.
        goto case "1";
}

// Выполнить некоторую дополнительную работу.
Console.WriteLine("На этом с основным потоком мы закончили.");
Console.ReadLine();