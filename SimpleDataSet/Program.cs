﻿using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            ManipulateDataRowState();
            PrintDataSet(carsInventoryDS);
            SaveAndLoadAsXml(carsInventoryDS);
            SaveAndLoadAsBinary(carsInventoryDS);

            Console.ReadLine();
        }

        private static void PrintDataSet(DataSet ds)
        {
            // Вывести имя DataSet и любые расширенные свойства.
            Console.WriteLine($"Имя DataSet: {ds.DataSetName}");
            foreach (DictionaryEntry de in ds.ExtendedProperties) Console.WriteLine($"Ключ = {de.Key}, Значение = {de.Value}");
            Console.WriteLine();

            // Вывести содержимое каждой таблицы, используя объект чтения данных.
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine($"=> Таблица {dt.TableName}:");

                // Вывести имена столбцов.
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++) Console.Write($"{dt.Columns[curCol].ColumnName}\t");
                Console.WriteLine();
                Console.WriteLine("----------------------------------");

                // Вызвать новый вспомогательный метод.
                PrintTable(dt);
            }
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

            // Установить первичный ключ этой таблицы.
            inventoryTable.PrimaryKey = new[] { inventoryTable.Columns[0] };

            // Наконец, добавить таблицу в DataSet.
            ds.Tables.Add(inventoryTable);
        }

        private static void ManipulateDataRowState()
        {
            // Создать объект temp типа DataTable для целей тестирования.
            DataTable temp = new DataTable("Temp");
            temp.Columns.Add(new DataColumn("TempColumn", typeof(int)));

            // RowState = Detached. 
            var row = temp.NewRow();
            Console.WriteLine($"После вызова NewRow(): {row.RowState}");

            // RowState = Added.
            temp.Rows.Add(row);
            Console.WriteLine($"После вызова Rows.Add(): {row.RowState}");

            // RowState = Added.
            row["TempColumn"] = 10;
            Console.WriteLine($"После первого присваивания: {row.RowState}");

            // RowState = Unchanged.
            temp.AcceptChanges();
            Console.WriteLine($"После вызова AcceptChanges: {row.RowState}");

            // RowState = Modified.
            row["TempColumn"] = 11;
            Console.WriteLine($"После первого присваивания: {row.RowState}");

            // RowState = Deleted.
            temp.Rows[0].Delete();
            Console.WriteLine($"После вызова Delete: {row.RowState}");
        }

        static void PrintTable(DataTable dt)
        {
            // Получить объект DataTableReader.
            DataTableReader dtReader = dt.CreateDataReader();

            // DataTableReader работает в точности как DataReader.
            while (dtReader.Read())
            {
                for (int i = 0; i < dtReader.FieldCount; i++)
                {
                    Console.Write($"{dtReader.GetValue(i).ToString().Trim()}\t");
                }
                Console.WriteLine();
            }
            dtReader.Close();
        }

        static void SaveAndLoadAsXml(DataSet carsInventoryDS)
        {
            // Сохранить этот объект DataSet в формате XML.
            carsInventoryDS.WriteXml("carsDataSet.xml");
            carsInventoryDS.WriteXmlSchema("carsDataSet.xsd");

            // Очистить объект DataSet.
            carsInventoryDS.Clear();

            // Загрузить объект DataSet из файла XML.
            carsInventoryDS.ReadXml("carsDataSet.xml");
        }

        static void SaveAndLoadAsBinary(DataSet carsInventoryDS)
        {
            // Установить флаг двоичной сериализации.
            carsInventoryDS.RemotingFormat = SerializationFormat.Binary;

            // Сохранить этот объект DataSet в двоичном виде.
            FileStream fs = new FileStream("BinaryCars.bin", FileMode.Create);
            BinaryFormatter bFormat = new BinaryFormatter();
            bFormat.Serialize(fs, carsInventoryDS);
            fs.Close();

            // Очистить объект DataSet.
            carsInventoryDS.Clear();

            // Загрузить объект DataSet из двоичного файла.
            fs = new FileStream("BinaryCars.bin", FileMode.Open);
            DataSet data = (DataSet)bFormat.Deserialize(fs);
        }
    }
}
