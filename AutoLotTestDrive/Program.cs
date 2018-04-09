using AutoLotDAL.EF;
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
            Database.SetInitializer(new DataInitializer());
            Console.WriteLine("***** ADO.NET EF Code First *****");
            Inventory car1 = new Inventory() { Make = "Yugo", Color = "Коричневый", PetName = "Брауни" };
            Inventory car2 = new Inventory() { Make = "SmartCar", Color = "Коричневый", PetName = "Шорти" };
            AddNewRecord(car1);
            AddNewRecord(car2);
            AddNewRecords(new List<Inventory> { car1, car2 });
            UpdateRecord(car1.CarId);
            PrintAllInventory();
            ShowAllOrders();
            ShowAllOrdersEagerlyFetched();
            PrintAllCustomersAndCreditRisks();
            CustomerRepo customerRepo = new CustomerRepo();
            Customer customer = customerRepo.GetOne(4);
            customerRepo.Context.Entry(customer).State = EntityState.Detached;
            CreditRisk risk = MakeCustomerARisk(customer);
            PrintAllCustomersAndCreditRisks();
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
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (Exception ex)
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
    }
}
