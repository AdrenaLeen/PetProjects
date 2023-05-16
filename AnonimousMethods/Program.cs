using AnonimousMethods;

Console.WriteLine("***** Анонимные методы *****");
int aboutToBlowCounter = 0;

// Создать объект Car обычным образом.
var c1 = new Car("СлагБаг", 100, 10);

// Зарегистрировать обработчики событий как анонимные методы.
c1.AboutToBlow += static delegate
{
    Console.WriteLine("Эй! Слишком быстро!");
};

c1.AboutToBlow += delegate (object? sender, CarEventArgs e)
{
    aboutToBlowCounter++;
    Console.WriteLine($"Сообщение от объекта Car: {e.msg}");
};

c1.Exploded += delegate (object? sender, CarEventArgs e)
{
    Console.WriteLine($"Критическое сообщение от объекта Car: {e.msg}");
};

// В конце концов, этот код будет инициировать события.
for (int i = 0; i < 6; i++) c1.Accelerate(20);
Console.WriteLine($"Событие AboutToBlow было инициировано {aboutToBlowCounter} раз.");

Console.WriteLine("******** Использование отбрасывания с анонимными методами ********");

Func<int, int, int> constant = delegate (int _, int _) { return 42; };
Console.WriteLine($"constant(3,4)={constant(3, 4)}");

Console.ReadLine();