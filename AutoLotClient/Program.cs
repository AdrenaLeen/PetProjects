using AutoLotDAL.BulkImport;
using AutoLotDAL.ConnectedLayer;
using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoLotClient
{
    class Program
    {
        static void Main()
        {
            InventoryDAL dal = new InventoryDAL();
            var list = dal.GetAllInventory();
            Console.WriteLine(" ************** Все машины ************** ");
            Console.WriteLine("CarId\tMake\tColor\tPet Name");
            foreach (Car itm in list) Console.WriteLine($"{itm.CarId}\t{itm.Make}\t{itm.Color}\t{itm.PetName}");
            Console.WriteLine();
            var car = dal.GetCar(list.OrderBy(x => x.Color).Select(x => x.CarId).First());
            Console.WriteLine(" ************** Первая машина по цвету ************** ");
            Console.WriteLine("CarId\tMake\tColor\tPet Name");
            Console.WriteLine($"{car.CarId}\t{car.Make}\t{car.Color}\t{car.PetName}");

            try
            {
                dal.DeleteCar(5);
                Console.WriteLine("Запись об автомобиле удалена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
            }
            
            string petName = dal.LookUpPetName(car.CarId);
            Console.WriteLine(" ************** Новая машина ************** ");
            Console.WriteLine($"Дружественное имя: {petName}");
            DoBulkCopy();
            Console.Write("Для продолжения нажмите <Enter>...");
            Console.ReadLine();
        }

        public static void DoBulkCopy()
        {
            Console.WriteLine(" ************** Do Bulk Copy ************** ");
            List<Car> cars = new List<Car>
            {
                new Car() {Color = "Blue", Make = "Honda", PetName = "MyCar1"},
                new Car() {Color = "Red", Make = "Volvo", PetName = "MyCar2"},
                new Car() {Color = "White", Make = "VW", PetName = "MyCar3"},
                new Car() {Color = "Yellow", Make = "Toyota", PetName = "MyCar4"}
            };
            ProcessBulkImport.ExecuteBulkImport(cars, "Inventory");
            InventoryDAL dal = new InventoryDAL();
            var list = dal.GetAllInventory();
            Console.WriteLine(" ************** Все машины ************** ");
            Console.WriteLine("CarId\tMake\tColor\tPet Name");
            foreach (Car itm in list) Console.WriteLine($"{itm.CarId}\t{itm.Make}\t{itm.Color}\t{itm.PetName}");
            Console.WriteLine();
        }
    }
}
