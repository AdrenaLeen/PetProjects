﻿using AutoLotDAL.EF;
using AutoLotDAL.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.Models;
using System.Data.Entity.Infrastructure;

namespace AutoLotTestDrive
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** ADO.NET EF Code First *****");
            PrintAllInventory();
            PrintAllCustomersAndCreditRisks();
            CustomerRepo customerRepo = new CustomerRepo();
            Customer customer = customerRepo.GetOne(5);
            customerRepo.Context.Entry(customer).State = EntityState.Detached;
            CreditRisk risk = MakeCustomerARisk(customer);
            PrintAllCustomersAndCreditRisks();
            UpdateRecordWIthConcurrency();
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

        private static void ShowAllOrders()
        {
            using (OrderRepo repo = new OrderRepo())
            {
                Console.WriteLine("*********** Ожидающие заказы ***********");
                foreach (Order itm in repo.GetAll())
                {
                    Console.WriteLine($"->{itm.Customer.FullName} ждёт {itm.Car.PetName}");
                }
            }
        }

        private static void ShowAllOrdersEagerlyFetched()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                Console.WriteLine("*********** Ожидающие заказы ***********");
                List<Order> orders = context.Orders.Include(x => x.Customer).Include(y => y.Car).ToList();
                foreach (Order itm in orders)
                {
                    Console.WriteLine($"-> {itm.Customer.FullName} ожидает {itm.Car.PetName}");
                }
            }
        }

        private static CreditRisk MakeCustomerARisk(Customer customer)
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                context.Customers.Attach(customer);
                context.Customers.Remove(customer);
                CreditRisk creditRisk = new CreditRisk()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                };
                context.CreditRisks.Add(creditRisk);
                CreditRisk creditRiskDupe = new CreditRisk()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                };
                context.CreditRisks.Add(creditRiskDupe);
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex);
                }
                return creditRisk;
            }
        }

        private static void PrintAllCustomersAndCreditRisks()
        {
            Console.WriteLine("*********** Заказчики ***********");
            using (CustomerRepo repo = new CustomerRepo())
            {
                foreach (Customer cust in repo.GetAll())
                {
                    Console.WriteLine($"-> {cust.FirstName} {cust.LastName} - это заказчик.");
                }
            }
            Console.WriteLine("*********** Кредитные риски ***********");
            using (CreditRiskRepo repo = new CreditRiskRepo())
            {
                foreach (CreditRisk risk in repo.GetAll())
                {
                    Console.WriteLine($"-> {risk.FirstName} {risk.LastName} - это кредитный риск!");
                }
            }
        }

        private static void UpdateRecordWIthConcurrency()
        {
            Inventory car = new Inventory() { Make = "Yugo", Color = "Коричневый", PetName = "Брауни" };
            AddNewRecord(car);
            InventoryRepo repo1 = new InventoryRepo();
            Inventory car1 = repo1.GetOne(car.CarId);
            car1.PetName = "Обновлено";
            InventoryRepo repo2 = new InventoryRepo();
            Inventory car2 = repo2.GetOne(car.CarId);
            car2.Make = "Nissan";
            repo1.Save(car1);
            try
            {
                repo2.Save(car2);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex);
            }
            RemoveRecordById(car1.CarId, car1.Timestamp);
        }

        private static void RemoveRecordById(int carId, byte[] timeStamp)
        {
            using (InventoryRepo repo = new InventoryRepo())
            {
                repo.Delete(carId, timeStamp);
            }
        }
    }
}
