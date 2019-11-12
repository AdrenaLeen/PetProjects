using AutoLotDALCore.EF;
using AutoLotDALCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AutoLotDALCore.DataInitialization
{
    public static class MyDataInitializer
    {
        public static void InitializeData(AutoLotContext context)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer {FirstName = "Dave", LastName = "Brenner"},
                new Customer {FirstName = "Matt", LastName = "Walton"},
                new Customer {FirstName = "Steve", LastName = "Hagen"},
                new Customer {FirstName = "Pat", LastName = "Walton"},
                new Customer {FirstName = "Bad", LastName = "Customer"},
            };
            customers.ForEach(x => context.Customers.Add(x));
            context.SaveChanges();

            List<Inventory> cars = new List<Inventory>
            {
                new Inventory {Make = "VW", Color = "Black", PetName = "Zippy"},
                new Inventory {Make = "Ford", Color = "Rust", PetName = "Rusty"},
                new Inventory {Make = "Saab", Color = "Black", PetName = "Mel"},
                new Inventory {Make = "Yugo", Color = "Yellow", PetName = "Clunker"},
                new Inventory {Make = "BMW", Color = "Black", PetName = "Bimmer"},
                new Inventory {Make = "BMW", Color = "Green", PetName = "Hank"},
                new Inventory {Make = "BMW", Color = "Pink", PetName = "Pinky"},
                new Inventory {Make = "Pinto", Color = "Black", PetName = "Pete"},
                new Inventory {Make = "Yugo", Color = "Brown", PetName = "Brownie"},
            };
            context.Cars.AddRange(cars);
            context.SaveChanges();

            List<Order> orders = new List<Order>
            {
                new Order {Car = cars[0], Customer = customers[0]},
                new Order {Car = cars[1], Customer = customers[1]},
                new Order {Car = cars[2], Customer = customers[2]},
                new Order {Car = cars[3], Customer = customers[3]},
            };
            orders.ForEach(x => context.Orders.Add(x));
            context.SaveChanges();

            context.CreditRisks.Add(
                new CreditRisk
                {
                    Id = customers[4].Id,
                    FirstName = customers[4].FirstName,
                    LastName = customers[4].LastName,
                });
            context.Database.OpenConnection();
            
            try
            {
                string tableName = context.GetTableName(typeof(CreditRisk));

                // В версии 2.0 интерполяция строк .NET должна отделяться от интерполяции SQL.
                string rawSqlString = $"SET IDENTITY_INSERT dbo.{tableName} ON;";
                context.Database.ExecuteSqlCommand(rawSqlString);
                context.SaveChanges();

                rawSqlString = $"SET IDENTITY_INSERT dbo.{tableName} OFF";
                context.Database.ExecuteSqlCommand(rawSqlString);
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        public static void RecreateDatabase(AutoLotContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }

        public static void ClearData(AutoLotContext context)
        {
            ExecuteDeleteSql(context, "Orders");
            ExecuteDeleteSql(context, "Customers");
            ExecuteDeleteSql(context, "Inventory");
            ExecuteDeleteSql(context, "CreditRisks");
            ResetIdentity(context);
        }

        private static void ExecuteDeleteSql(AutoLotContext context, string tableName)
        {
            // В версии 2.0 интерполяция строк должна отделяться, если параметры не передаются.
            string rawSqlString = $"Delete from dbo.{tableName}";
            context.Database.ExecuteSqlCommand(rawSqlString);
        }

        private static void ResetIdentity(AutoLotContext context)
        {
            string[] tables = new[] { "Inventory", "Orders", "Customers", "CreditRisks" };
            foreach (string itm in tables)
            {
                // В версии 2.0 интерполяция строк должна отделяться, если параметры не передаются.
                string rawSqlString = $"DBCC CHECKIDENT (\"dbo.{itm}\", RESEED, -1);";
                context.Database.ExecuteSqlCommand(rawSqlString);
            }
        }
    }
}
