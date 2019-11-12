using AutoLotDALCore.DataInitialization;
using AutoLotDALCore.EF;
using AutoLotDALCore.Models;
using AutoLotDALCore.Repos;
using System;

namespace AutoLotDALCoreTestDriver
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** ADO.NET EF Core *****");
            using (AutoLotContext context = new AutoLotContext())
            {
                MyDataInitializer.RecreateDatabase(context);
                MyDataInitializer.InitializeData(context);
                foreach (Inventory c in context.Cars) Console.WriteLine(c);
                Console.WriteLine();

                Console.WriteLine("***** Использование репозитория *****");
                using InventoryRepo repo = new InventoryRepo(context);
                foreach (Inventory c in repo.GetAll()) Console.WriteLine(c);
            }

            Console.ReadLine();
        }
    }
}
