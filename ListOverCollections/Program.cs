﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            LINQOverArrayList();
            OfTypeAsFilter();

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

        static void LINQOverArrayList()
        {
            Console.WriteLine("***** LINQ над ArrayList *****");

            // Необобщённая коллекция объектов Car.
            ArrayList myCars = new ArrayList() {
                new Car{ PetName = "Генри", Color = "Серебряный", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Дейзи", Color = "Жёлто-коричневый", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Мэри", Color = "Чёрный", Speed = 55, Make = "VW"},
                new Car{ PetName = "Драндулет", Color = "Ржавый", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Мэлвин", Color = "Белый", Speed = 43, Make = "Ford"}
              };

            // Трансформировать ArrayList в тип, совместимый с IEnumerable<T>.
            IEnumerable<Car> myCarsEnum = myCars.OfType<Car>();

            // Создать выражение запроса, нацеленное на совместимый с IEnumerable<T> тип.
            IEnumerable<Car> fastCars = from c in myCarsEnum where c.Speed > 55 select c;

            foreach (Car car in fastCars) Console.WriteLine($"{car.PetName} едет слишком быстро!");
            Console.WriteLine();
        }

        static void OfTypeAsFilter()
        {
            // Извлечь из ArrayList целочисленные значения.
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "строковые данные" });
            IEnumerable<int> myInts = myStuff.OfType<int>();

            // Выводит 10, 400 и 8.
            foreach (int i in myInts) Console.WriteLine($"Целочисленное значение: {i}");
            Console.WriteLine();
        }
    }
}
