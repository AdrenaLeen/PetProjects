using ThreadPoolApp;

Console.WriteLine("***** Пул потоков CLR *****");

Console.WriteLine($"Запущен главный поток. ThreadID = {Environment.CurrentManagedThreadId}");
var p = new Printer();
var workItem = new WaitCallback(PrintTheNumbers);

// Поставить в очередь метод 10 раз.
for (int i = 0; i < 10; i++) ThreadPool.QueueUserWorkItem(workItem, p);

Console.WriteLine("Все задачи поставлены в очередь.");
Console.ReadLine();

static void PrintTheNumbers(object? state)
{
    var task = state as Printer;
    task?.PrintNumbers();
}