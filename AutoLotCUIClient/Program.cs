using AutoLotDAL.ConnectedLayer;
using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

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
                    Console.WriteLine();
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
                            ListInventoryViaList(invDAL);
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

        private static void ListInventoryViaList(InventoryDAL invDAL)
        {
            // Получить список автомобилей на складе.
            List<NewCar> record = invDAL.GetAllInventoryAsList();

            Console.WriteLine("CarId:\tMake:\tColor:\tPetName:");
            foreach (NewCar c in record)
            {
                Console.WriteLine($"{c.CarId}\t{c.Make}\t{c.Color}\t{c.PetName}");
            }
        }

        private static void ListInventory(InventoryDAL invDAL)
        {
            // Получить список автомобилей на складе.
            DataTable dt = invDAL.GetAllInventoryAsDataTable();

            // Передать объект DataTable во вспомогательную функцию для отображения.
            DisplayTable(dt);
        }

        private static void DisplayTable(DataTable dt)
        {
            // Вывести имена столбцов.
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.Write($"{dt.Columns[curCol].ColumnName}\t");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            // Вывести содержимое объекта DataTable.
            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write($"{dt.Rows[curRow][curCol]}\t");
                }
                Console.WriteLine();
            }
        }

        private static void DeleteCar(InventoryDAL invDAL)
        {
            // Получить идентификатор автомобиля, запись о котором должна быть удалена.
            Console.Write("Введите идентификатор автомобиля для удаления: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            // На случай нарушения ссылочной целостности.
            try
            {
                invDAL.DeleteCar(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateCarPetName(InventoryDAL invDAL)
        {
            throw new NotImplementedException();
        }

        private static void InsertNewCar(InventoryDAL invDAL)
        {
            // Получить пользовательские данные.
            Console.Write("Введите цвет автомобиля: ");
            string newCarColor = Console.ReadLine();
            Console.Write("Введите модель автомобиля: ");
            string newCarMake = Console.ReadLine();
            Console.Write("Введите дружественное имя автомобиля: ");
            string newCarPetName = Console.ReadLine();

            // Передать информацию библиотеке доступа к данным.
            NewCar c = new NewCar
            {
                Color = newCarColor,
                Make = newCarMake,
                PetName = newCarPetName
            };
            invDAL.InsertAuto(c);
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
