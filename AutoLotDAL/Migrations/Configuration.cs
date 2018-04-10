namespace AutoLotDAL.Migrations
{
    using AutoLotDAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EF.AutoLotEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AutoLotDAL.EF.AutoLotEntities";
        }

        protected override void Seed(EF.AutoLotEntities context)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer {FirstName = "Дейв", LastName = "Бреннер"},
                new Customer {FirstName = "Мэтт", LastName = "Уолтон"},
                new Customer {FirstName = "Стив", LastName = "Хаген"},
                new Customer {FirstName = "Пэт", LastName = "Уолтон"},
                new Customer {FirstName = "Плохой", LastName = "Заказчик"},
            };
            customers.ForEach(x => context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName }, x));
            List<Inventory> cars = new List<Inventory>
            {
                new Inventory {Make = "VW", Color = "Чёрный", PetName = "Живчик"},
                new Inventory {Make = "Ford", Color = "Ржавый", PetName = "Расти"},
                new Inventory {Make = "Saab", Color = "Чёрный", PetName = "Мэл"},
                new Inventory {Make = "Yugo", Color = "Жёлтый", PetName = "Драндулет"},
                new Inventory {Make = "BMW", Color = "Чёрный", PetName = "Бумер"},
                new Inventory {Make = "BMW", Color = "Зелёный", PetName = "Хэнк"},
                new Inventory {Make = "BMW", Color = "Розовый", PetName = "Пинки"},
                new Inventory {Make = "Pinto", Color = "Чёрный", PetName = "Пит"},
                new Inventory {Make = "Yugo", Color = "Коричневый", PetName = "Брауни"},
            };
            cars.ForEach(x => context.Inventory.AddOrUpdate(i => new { i.Make, i.Color, i.PetName }, x));
            List<Order> orders = new List<Order>
            {
                new Order {Car = cars[0], Customer = customers[0]},
                new Order {Car = cars[1], Customer = customers[1]},
                new Order {Car = cars[2], Customer = customers[2]},
                new Order {Car = cars[3], Customer = customers[3]},
            };
            orders.ForEach(x => context.Orders.AddOrUpdate(o => new { o.CarId, o.CustId }, x));
            context.CreditRisks.AddOrUpdate(c => new { c.FirstName, c.LastName },
                new CreditRisk
                {
                    CustId = customers[4].CustId,
                    FirstName = customers[4].FirstName,
                    LastName = customers[4].LastName,
                });
        }
    }
}
