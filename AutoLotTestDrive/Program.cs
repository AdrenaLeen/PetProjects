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
    }
}
