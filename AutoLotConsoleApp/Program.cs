﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotConsoleApp.EF;

namespace AutoLotConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** ADO.NET EF *****");
            int carId = AddNewRecord();
            Console.WriteLine(carId);
            PrintAllInventory();
            FunWithLinqQueries();
            Console.ReadLine();
        }

        private static int AddNewRecord()
        {
            // Добавить запись в таблицу Inventory базы данных AutoLot.
            using (AutoLotEntities context = new AutoLotEntities())
            {
                try
                {
                    // В целях тестирования жёстко закодировать данные для новой записи.
                    Car car = new Car() { Make = "Yugo", Color = "Коричневый", CarNickName = "Брауни" };
                    context.Cars.Add(car);
                    context.SaveChanges();
                    
                    // В случае успешного сохранения EF заполняет поле идентификатора значением, сгенерированным базой данных.
                    return car.CarId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return 0;
                }
            }
        }

        private static void PrintAllInventory()
        {
            // Выбрать все элементы из таблицы Inventory базы данных AutoLot и вывести данные с применением специального метода ToString() сущностного класса Car.
            using (AutoLotEntities context = new AutoLotEntities())
            {
                IQueryable<Car> cars = context.Cars.Where(c => c.Make == "BMW");
                foreach (Car c in cars) Console.WriteLine(c);
            }
        }

        private static void FunWithLinqQueries()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                // Получить все данные из таблицы Inventory.
                Car[] allData = context.Cars.ToArray();

                // Получить проекцию новых данных.
                var colorsMakes = from item in allData select new { item.Color, item.Make };
                foreach (var item in colorsMakes) Console.WriteLine(item);

                // Получить только элементы, в которых Color == "Чёрный".
                IEnumerable<Car> blackCars = from item in allData where item.Color == "Чёрный" select item;
                foreach (Car item in blackCars) Console.WriteLine(item);
            }
        }
    }
}