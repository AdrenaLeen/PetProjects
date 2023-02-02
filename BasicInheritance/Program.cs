using BasicInheritance;

Console.WriteLine("***** Базовое наследование *****");
// Создать объект Car и установить максимальную и текущую скорости.
var myCar = new Car(80) { Speed = 50 };
Console.WriteLine($"Моя машина едет со скоростью {myCar.Speed} км/ч");

// Создать объект MiniVan.
var myVan = new MiniVan { Speed = 10 };
Console.WriteLine($"Мой вэн едет со скоростью {myVan.Speed} км/ч");

Console.ReadLine();