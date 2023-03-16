using CustomEnumerator;

Console.WriteLine("***** IEnumerable / IEnumerator *****");
var carLot = new Garage();

// Проход по всем объектам Car в коллекции?
foreach (Car c in carLot) Console.WriteLine($"{c.PetName} едет со скоростью {c.CurrentSpeed} км/ч");

Console.ReadLine();