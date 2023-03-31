using SimpleDispose;

Console.WriteLine("***** Освобождение объектов *****");

// Метод Dispose() вызывается автоматически при выходе за пределы области действия using.
using (var rw = new MyResourceWrapper())
{
    // Использовать объект rw.
}

// Использование списка с разделителями-запятыми для объявления нескольких объектов, подлежащих освобождению.
using (MyResourceWrapper rw = new(), rw2 = new())
{
    // Работать с объектами rw и rw2.
}

Console.WriteLine("Объявления using");
UsingDeclaration();
Console.ReadLine();

static void UsingDeclaration()
{
    // Эта переменная будет находиться в области видимости вплоть до конца метода.
    using var rw = new MyResourceWrapper();

    // Сделать что-нибудь.
    Console.WriteLine("Утилизация");
    // В этой точке переменная освобождается.
}