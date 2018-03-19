using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using AutoLotDAL.ConnectedLayer;

namespace AutoLotCUIClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** AutoLot Console UI *****");

            // Получить строку подключения из файла App.config.
            string connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            bool userDone = false;
            string userCommand = "";

            // Создать объект InventoryDAL.
            InventoryDAL invDAL = new InventoryDAL();
            invDAL.OpenConnection(connectionString);

            // Продолжать запрашивать у пользователя ввод вплоть до получения команды Q.
            try
            {
                ShowInstructions();
                do
                {
                    Console.Write("Пожалуйста, введите команду: ");
                    userCommand = Console.ReadLine();
                    Console.WriteLine();
                    switch (userCommand?.ToUpper() ?? "")
                    {
                        case "I":
                            InsertNewCar(invDAL);
                            break;
                        case "U":
                            UpdateCarPetName(invDAL);
                            break;
                        case "D":
                            DeleteCar(invDAL);
                            break;
                        case "L":
                            ListInventory(invDAL);
                            break;
                        case "S":
                            ShowInstructions();
                            break;
                        case "P":
                            LookUpPetName(invDAL);
                            break;
                        case "Q":
                            userDone = true;
                            break;
                        default:
                            Console.WriteLine("Неправильные данные! Попробуйте снова.");
                            break;
                    }
                } while (!userDone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                invDAL.CloseConnection();
            }
        }

        private static void LookUpPetName(InventoryDAL invDAL)
        {
            throw new NotImplementedException();
        }

        private static void ListInventory(InventoryDAL invDAL)
        {
            throw new NotImplementedException();
        }

        private static void DeleteCar(InventoryDAL invDAL)
        {
            throw new NotImplementedException();
        }

        private static void UpdateCarPetName(InventoryDAL invDAL)
        {
            throw new NotImplementedException();
        }

        private static void InsertNewCar(InventoryDAL invDAL)
        {
            throw new NotImplementedException();
        }

        private static void ShowInstructions()
        {
            Console.WriteLine("I: Вставить новую запись об автомобиле.");
            Console.WriteLine("U: Обновить существующую запись об автомобиле.");
            Console.WriteLine("D: Удалить существующую запись об автомобиле.");
            Console.WriteLine("L: Вывести текущий инвентарный список автомобилей.");
            Console.WriteLine("S: Вывести информацию об этих командах.");
            Console.WriteLine("P: Найти дружественное имя автомобиля.");
            Console.WriteLine("Q: Завершить программу.");
        }
    }
}
