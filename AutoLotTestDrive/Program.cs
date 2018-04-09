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
    }
}
