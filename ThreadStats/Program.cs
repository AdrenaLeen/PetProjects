Console.WriteLine("***** Статистика о текущем потоке *****");

// Получить имя текущего потока.
Thread primaryThread = Thread.CurrentThread;
primaryThread.Name = "ThePrimaryThread";

// Вывести некоторую статистику о текущем потоке.
Console.WriteLine($"Идентификатор текущего потока: {primaryThread.ManagedThreadId}");
Console.WriteLine($"Имя потока: {primaryThread.Name}");
Console.WriteLine($"Запущен ли поток?: {primaryThread.IsAlive}");
Console.WriteLine($"Приоритет потока: {primaryThread.Priority}");
Console.WriteLine($"Состояние потока: {primaryThread.ThreadState}");
Console.ReadLine();