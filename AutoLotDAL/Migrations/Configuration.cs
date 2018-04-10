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
                new Customer {FirstName = "����", LastName = "�������"},
                new Customer {FirstName = "����", LastName = "������"},
                new Customer {FirstName = "����", LastName = "�����"},
                new Customer {FirstName = "���", LastName = "������"},
                new Customer {FirstName = "������", LastName = "��������"},
            };
            customers.ForEach(x => context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName }, x));
            List<Inventory> cars = new List<Inventory>
            {
                new Inventory {Make = "VW", Color = "׸����", PetName = "������"},
                new Inventory {Make = "Ford", Color = "������", PetName = "�����"},
                new Inventory {Make = "Saab", Color = "׸����", PetName = "���"},
                new Inventory {Make = "Yugo", Color = "Ƹ����", PetName = "���������"},
                new Inventory {Make = "BMW", Color = "׸����", PetName = "�����"},
                new Inventory {Make = "BMW", Color = "������", PetName = "����"},
                new Inventory {Make = "BMW", Color = "�������", PetName = "�����"},
                new Inventory {Make = "Pinto", Color = "׸����", PetName = "���"},
                new Inventory {Make = "Yugo", Color = "����������", PetName = "������"},
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
