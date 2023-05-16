using CarEvents;

Console.WriteLine("***** События *****");
var c1 = new Car("СлагБаг", 100, 10);

// Зарегистрировать обработчики событий.
c1.AboutToBlow += CarIsAlmostDoomed;
c1.AboutToBlow += CarAboutToBlow;
c1.Exploded += CarExploded;

Console.WriteLine("***** Увеличение скорости *****");
for (int i = 0; i < 6; i++) c1.Accelerate(20);

// Удалить метод CarExploded из списка вызовов.
c1.Exploded -= CarExploded;

Console.WriteLine("***** Увеличение скорости *****");
for (int i = 0; i < 6; i++) c1.Accelerate(20);

Console.ReadLine();

static void CarAboutToBlow(object? sender, CarEventArgs e)
{
    // Просто для подстраховки перед приведением произвести проверку во время выполнения.
    if (sender is Car c) Console.WriteLine($"Критическое сообщение от {c.PetName}: {e.msg}");
}

static void CarIsAlmostDoomed(object? sender, CarEventArgs e) => Console.WriteLine($"=> Критическое сообщение от объекта Car: {e.msg}");

static void CarExploded(object? sender, CarEventArgs e) => Console.WriteLine(e.msg);