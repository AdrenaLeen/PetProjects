using AutoLotDAL.EF;
using AutoLotDAL.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.Models;

namespace AutoLotTestDrive
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new DataInitializer());
            Console.WriteLine("***** ADO.NET EF Code First *****");
            Inventory car1 = new Inventory() { Make = "Yugo", Color = "Коричневый", PetName = "Брауни" };
            Inventory car2 = new Inventory() { Make = "SmartCar", Color = "Коричневый", PetName = "Шорти" };
            AddNewRecord(car1);
            AddNewRecord(car2);
            AddNewRecords(new List<Inventory> { car1, car2 });
            UpdateRecord(car1.CarId);
            PrintAllInventory();
            Console.ReadLine();
        }

        private static void PrintAllInventory()
        {
            using (InventoryRepo repo = new InventoryRepo())
            {
                foreach (Inventory c in repo.GetAll()) Console.WriteLine(c);
            }
        }

        private static void AddNewRecord(Inventory car)
        {
            // Добавить запись в таблицу Inventory базы данных AutoLot.
            using (InventoryRepo repo = new InventoryRepo())
            {
                repo.Add(car);
            }
        }

        private static void AddNewRecords(IList<Inventory> cars)
        {
            // Добавить записи в таблицу Inventory базы данных AutoLot.
            using (InventoryRepo repo = new InventoryRepo())
            {
                repo.AddRange(cars);
            }
        }

        private static void UpdateRecord(int carId)
        {
            using (InventoryRepo repo = new InventoryRepo())
            {
                // Получить запись об автомобиле, изменить её и сохранить!
                Inventory carToUpdate = repo.GetOne(carId);
                if (carToUpdate != null)
                {
                    Console.WriteLine($"До изменения: {repo.Context.Entry(carToUpdate).State}");
                    carToUpdate.Color = "Голубой";
                    Console.WriteLine($"После изменения: {repo.Context.Entry(carToUpdate).State}");
                    repo.Save(carToUpdate);
                    Console.WriteLine($"После сохранения: {repo.Context.Entry(carToUpdate).State}");
                }
            }
        }
    }
}
