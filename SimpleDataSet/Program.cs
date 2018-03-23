﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SimpleDataSet
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** DataSet *****");

            // Создать объект DataSet и добавить несколько свойств.
            DataSet carsInventoryDS = new DataSet("Car Inventory");

            carsInventoryDS.ExtendedProperties["TimeStamp"] = DateTime.Now;
            carsInventoryDS.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            carsInventoryDS.ExtendedProperties["Company"] = "Mikko’s Hot Tub Super Store";

            FillDataSet(carsInventoryDS);
            PrintDataSet(carsInventoryDS);
            
            Console.ReadLine();
        }

        private static void PrintDataSet(DataSet carsInventoryDS)
        {
            throw new NotImplementedException();
        }

        private static void FillDataSet(DataSet ds)
        {
            // Создать столбцы данных, которые отображаются на "реальные" столбцы в таблице Inventory из базы данных AutoLot.
            DataColumn carIDColumn = new DataColumn("CarID", typeof(int))
            {
                Caption = "Идентификатор автомобиля",
                ReadOnly = true,
                AllowDBNull = false,
                Unique = true,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1
            };

            DataColumn carMakeColumn = new DataColumn("Make", typeof(string));
            DataColumn carColorColumn = new DataColumn("Color", typeof(string));
            DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string)) { Caption = "Дружественное имя" };

            // Добавить объекты DataColumn в DataTable.
            DataTable inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(new[] {carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn});

            // Добавить несколько строк в таблицу Inventory.
            DataRow carRow = inventoryTable.NewRow();
            carRow["Make"] = "BMW";
            carRow["Color"] = "Чёрный";
            carRow["PetName"] = "Гамлет";
            inventoryTable.Rows.Add(carRow);

            carRow = inventoryTable.NewRow();
            // Столбец 0 - это автоинкрементное поле идентификатора, поэтому начать заполнение со столбца 1.
            carRow[1] = "Saab";
            carRow[2] = "Красный";
            carRow[3] = "Морской бриз";
            inventoryTable.Rows.Add(carRow);
        }
    }
}
