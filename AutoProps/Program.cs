using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Автоматические свойства *****");
            // Создать объект автомобиля.
            Car c = new Car();
            c.PetName = "Франк";
            c.Speed = 55;
            c.Color = "Красный";
            Console.WriteLine($"Вашу машину зовут {c.PetName}? Это странно...");
            c.DisplayStats();
            // Поместить автомобиль в гараж.
            Garage g = new Garage();
            g.MyAuto = c;
            // Нормально, выводится стандартное значение 0.
            // Вывести количество автомобилей в гараже
            Console.WriteLine($"Число машин в гараже: {g.NumberOfCars}");
            // Ошибка времени выполнения! Поддерживающее поле в данный момент равно null!
            // Вывести название автомобиля.
            Console.WriteLine($"Вашу машину зовут: {g.MyAuto.PetName}");

            Console.ReadLine();
        }
    }
}
