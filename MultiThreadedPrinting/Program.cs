using MultiThreadedPrinting;

Console.WriteLine("***** Синхронизация потоков *****");

var p = new Printer();

// Создать 10 потоков, которые указывают на один и тот же метод того же самого объекта.
var threads = new Thread[10];
for (int i = 0; i < 10; i++) threads[i] = new Thread(new ThreadStart(p.PrintNumbers)) { Name = string.Format($"Рабочий поток #{i}") };

// Теперь запустить их все
foreach (Thread t in threads) t.Start();

Console.WriteLine("Использование Interlocked");
int intVal = 5;
object myLockToken = new();
lock (myLockToken)
{
    intVal++;
}
Console.WriteLine(intVal);
Interlocked.Increment(ref intVal);
Console.WriteLine(intVal);

Console.ReadLine();