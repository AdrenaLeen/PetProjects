using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoLotDAL.Models;

namespace AutoLotDAL.EF
{
    public class DataInitializer: DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer {FirstName = "Дейв", LastName = "Бреннер"},
                new Customer {FirstName = "Мэтт", LastName = "Уолтон"},
                new Customer {FirstName = "Стив", LastName = "Хаген"},
                new Customer {FirstName = "Пэт", LastName = "Уолтон"},
                new Customer {FirstName = "Плохой", LastName = "Заказчик"},
            };
            customers.ForEach(x => context.Customers.Add(x));
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
            cars.ForEach(x => context.Inventory.Add(x));
            List<Order> orders = new List<Order>
            {
                new Order {Car = cars[0], Customer = customers[0]},
                new Order {Car = cars[1], Customer = customers[1]},
                new Order {Car = cars[2], Customer = customers[2]},
                new Order {Car = cars[3], Customer = customers[3]},
            };
            orders.ForEach(x => context.Orders.Add(x));
            context.CreditRisks.Add(
                new CreditRisk
                {
                    CustId = customers[4].CustId,
                    FirstName = customers[4].FirstName,
                    LastName = customers[4].LastName,
                });
            context.SaveChanges();
        }
    }
}
