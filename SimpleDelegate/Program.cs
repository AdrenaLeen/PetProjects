using SimpleDelegate;

Console.WriteLine("***** Пример простейшего делегата *****");

// Создать объект делегата BinaryOp, который "указывает" на SimpleMath.Add().
// Делегаты .NET могут также указывать на методы экземпляра.
var b = new BinaryOp(SimpleMath.Add);

// Вывести сведения об объекте.
DisplayDelegateInfo(b);

// Вызвать метод Add() косвенно с использованием объекта делегата.
// В действительности здесь вызывается метод Invoke()!
Console.WriteLine($"10 + 10 равно {b(10, 10)}");

Console.ReadLine();

static void DisplayDelegateInfo(Delegate delObj)
{
    // Вывести имена всех членов в списке вызовов делегата.
    foreach (Delegate d in delObj.GetInvocationList())
    {
        Console.WriteLine($"Название метода: {d.Method}");
        Console.WriteLine($"Название типа: {d.Target}");
    }
}