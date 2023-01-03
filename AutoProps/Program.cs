using AutoProps;

Console.WriteLine("***** Автоматические свойства *****");

// Создать объект автомобиля.
var c = new Car
{
    PetName = "Франк",
    Speed = 55,
    Color = "Красный"
};
Console.WriteLine($"Вашу машину зовут {c.PetName}? Это странно...");
c.DisplayStats();

// Поместить автомобиль в гараж.
var g = new Garage { MyAuto = c };

// Вывести количество автомобилей в гараже
Console.WriteLine($"Число машин в гараже: {g.NumberOfCars}");

// Вывести название автомобиля.
Console.WriteLine($"Вашу машину зовут: {g.MyAuto.PetName}");

Console.ReadLine();