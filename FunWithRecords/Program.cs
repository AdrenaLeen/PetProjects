using FunWithRecords;

Console.WriteLine("***** Записи *****");

// Использовать инициализацию объекта.
var myCar = new Car
{
    Make = "Honda",
    Model = "Pilot",
    Color = "Синий"
};
Console.WriteLine("Моя машина:");
DisplayCarStats(myCar);
Console.WriteLine();

// Использовать специальный конструктор.
var anotherMyCar = new Car("Honda", "Pilot", "Синий");
Console.WriteLine("Еще одна переменная для моей машины:");
DisplayCarStats(anotherMyCar);
Console.WriteLine();

Console.WriteLine($"Эквивалентны ли экземляры Car? {myCar.Equals(anotherMyCar)}");
Console.WriteLine($"Указывают ли экземпляры Car на тот же самый объект? {ReferenceEquals(myCar, anotherMyCar)}");
Console.WriteLine();

// Использовать инициализацию объекта.
var myCarRecord = new CarRecord("Honda", "Pilot", "Синий");
Console.WriteLine("Моя машина:");
Console.WriteLine(myCarRecord.ToString());
Console.WriteLine();

// Использовать специальный конструктор.
var anotherMyCarRecord = new CarRecord("Honda", "Pilot", "Синий");
Console.WriteLine("Еще одна переменная для моей машины:");
Console.WriteLine(anotherMyCarRecord.ToString());
Console.WriteLine();

Console.WriteLine($"Эквивалентны ли экземляры CarRecord? {myCarRecord.Equals(anotherMyCarRecord)}");
Console.WriteLine($"Указывают ли экземпляры CarRecord на тот же самый объект? {ReferenceEquals(myCarRecord, anotherMyCarRecord)}");
Console.WriteLine($"Эквивалентны ли экземляры CarRecord? {myCarRecord == anotherMyCarRecord}");
Console.WriteLine($"Не эквивалентны ли экземляры CarRecord? {myCarRecord != anotherMyCarRecord}");
Console.WriteLine();

CarRecord carRecordCopy = anotherMyCarRecord;
Console.WriteLine("Результаты копирования CarRecord");
Console.WriteLine($"Эквивалентны ли экземляры CarRecord? {carRecordCopy.Equals(anotherMyCarRecord)}");
Console.WriteLine($"Указывают ли экземпляры CarRecord на тот же самый объект? {ReferenceEquals(carRecordCopy, anotherMyCarRecord)}");
Console.WriteLine();

CarRecord ourOtherCar = myCarRecord with { Model = "Odyssey" };
Console.WriteLine("Моя скопированная машина:");
Console.WriteLine(ourOtherCar.ToString());
Console.WriteLine();

Console.WriteLine("Результаты копирования CarRecord с использованием выражения with");
Console.WriteLine($"Эквивалентны ли экземляры CarRecord? {ourOtherCar.Equals(myCarRecord)}");
Console.WriteLine($"Указывают ли экземпляры CarRecord на тот же самый объект? {ReferenceEquals(ourOtherCar, myCarRecord)}");

Console.ReadLine();


static void DisplayCarStats(Car c)
{
    Console.WriteLine($"Марка машины: {c.Make}");
    Console.WriteLine($"Модель машины: {c.Model}");
    Console.WriteLine($"Цвет машины: {c.Color}");
}