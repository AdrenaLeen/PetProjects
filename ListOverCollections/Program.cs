using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOverCollections
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Применение LINQ к объектам коллекций *****");

            // Создать список List<> объектов Car.
            List<Car> myCars = new List<Car>() {
                new Car{ PetName = "Генри", Color = "Серебряный", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Дейзи", Color = "Жёлто-коричневый", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Мэри", Color = "Чёрный", Speed = 55, Make = "VW"},
                new Car{ PetName = "Драндулет", Color = "Ржавый", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Мэлвин", Color = "Белый", Speed = 43, Make = "Ford"}
            };

            GetFastCars(myCars);
            GetFastBMWs(myCars);

            Console.ReadLine();
        }

        static void GetFastCars(List<Car> myCars)
        {
            // Найти в List<> все объекты Car, у которых значение Speed больше 55.
            IEnumerable<Car> fastCars = from c in myCars where c.Speed > 55 select c;

            foreach (Car car in fastCars) Console.WriteLine($"{car.PetName} едет слишком быстро!");
            Console.WriteLine();
        }

        static void GetFastBMWs(List<Car> myCars)
        {
            // Найти быстрые автомобили BMW!
            IEnumerable<Car> fastCars = from c in myCars where c.Speed > 90 && c.Make == "BMW" select c;

            foreach (Car car in fastCars) Console.WriteLine($"{car.PetName} едет слишком быстро!");
            Console.WriteLine();
        }
    }
}
