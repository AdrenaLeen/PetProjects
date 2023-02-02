using RecordInheritance;

Console.WriteLine("Наследование с типами записей");

_ = new Car("Honda", "Pilot", "Blue");

var m = new MiniVan("Honda", "Pilot", "Blue", 10);

Console.WriteLine($"Проверка, является ли MiniVan типом Car: {m is Car}");
Console.WriteLine();

_ = new PositionalCar("Honda", "Pilot", "Blue");

var pm = new PositionalMiniVan("Honda", "Pilot", "Blue", 10);

Console.WriteLine($"Проверка, является ли PositionalMiniVan типом PositionalCar: {pm is PositionalCar}");
Console.WriteLine();

var mc = new MotorCycle("Harley", "Lowrider");
var sc = new Scooter("Harley", "Lowrider");

Console.WriteLine($"MotorCycle и Scooter эквивалентны: {Equals(mc, sc)}");
Console.ReadLine();