using SimpleClassExample;

Console.WriteLine("***** Тип класса *****");

// Разместить в памяти и сконфигурировать объект Car.
var myCar = new Car
{
    petName = "Генри",
    currSpeed = 10
};

// Увеличить скорость автомобиля в несколько раз и вывести новое состояние.
for (int i = 0; i <= 10; i++)
{
    myCar.SpeedUp(5);
    myCar.PrintState();
}

var myCar2 = new Car();
myCar.petName = "Фред";

Car myCar3;
myCar3 = new Car
{
    petName = "Фред"
};

// Вызов стандартного конструктора
var chuck = new Car();
// Выводит строку "Чак едет со скоростью 10 км/ч."
chuck.PrintState();

// Создать объект Car по имени Мэри со скоростью 0 км/ч.
var mary = new Car("Мэри");
mary.PrintState();

// Создать объект Car по имени Дейзи со скоростью 75 км/ч.
var daisy = new Car("Дейзи", 75);
daisy.PrintState();

var mc = new Motorcycle();
mc.PopAWheely();

// Создать объект Motorcycle с мотоциклистом по имени Тини?
var c = new Motorcycle(5);
c.SetDriverName("Тини");
c.PopAWheely();
// Выводит пустое значение name!
// Вывод имени гонщика.
Console.WriteLine($"Мотоциклиста зовут {c.driverName}");

MakeSomeBikes();

Console.ReadLine();

static void MakeSomeBikes()
{
    // driverName = "", driverIntensity = 0  
    var m1 = new Motorcycle();
    Console.WriteLine($"Название = {m1.driverName}, Мощность = {m1.driverIntensity}");

    // driverName = "Тини", driverIntensity = 0 
    var m2 = new Motorcycle(name: "Тини");
    Console.WriteLine($"Название = {m2.driverName}, Мощность = {m2.driverIntensity}");

    // driverName = "", driverIntensity = 7  
    var m3 = new Motorcycle(7);
    Console.WriteLine($"Название = {m3.driverName}, Мощность = {m3.driverIntensity}");
}