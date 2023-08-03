using AddWithThreads;

Console.WriteLine("***** Сложение с помощью объектов Thread *****");
Console.WriteLine($"Идентификатор потока в Main(): {Environment.CurrentManagedThreadId}");

var waitHandle = new AutoResetEvent(false);

// Создать объект AddParams для передачи вторичному потоку.
var ap = new AddParams(10, 10);
var t = new Thread(new ParameterizedThreadStart(Add));
t.Start(ap);

// Ожидать, пока не поступит уведомление!
waitHandle.WaitOne();

Console.WriteLine("Другой поток завершён!");
Console.ReadLine();

void Add(object? data)
{
    if (data is AddParams ap)
    {
        Console.WriteLine($"Идентификатор потока в Add(): {Environment.CurrentManagedThreadId}");
        Console.WriteLine($"{ap.a} + {ap.b} равно {ap.a + ap.b}");

        // Сообщить другому потоку о том, что работа завершена.
        waitHandle.Set();
    }
}