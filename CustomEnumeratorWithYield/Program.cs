using CustomEnumeratorWithYield;

Console.WriteLine("***** Ключевое слово yield *****");
var carLot = new Garage();
try
{
    // На этот раз возникает ошибка.
    var carEnumerator = carLot.GetEnumerator();
}
catch (Exception ex)
{
    Console.WriteLine($"Исключение возникло в GetEnumerator {ex.Message}");
}

// Получить элементы, используя GetEnumerator().
foreach (Car c in carLot) Console.WriteLine($"{c.PetName} едет со скоростью {c.CurrentSpeed} км/ч");
Console.WriteLine();

// Получить элементы (в обратном порядке!), используя именованный итератор.
foreach (Car c in carLot.GetTheCars(true)) Console.WriteLine($"{c.PetName} едет со скоростью {c.CurrentSpeed} км/ч");

Console.ReadLine();