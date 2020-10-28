using AutoLotDAL.DataSets;
using AutoLotDAL.DataSets.AutoLotDataSetTableAdapters;
using System;
using System.Data;
using System.Linq;

namespace LinqToDataSetApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** LINQ to DataSet *****");

            // Получить строго типизированный объект DataTable, содержащий текущие данные таблицы Inventory из базы данных AutoLot.
            AutoLotDataSet dal = new AutoLotDataSet();
            InventoryTableAdapter tableAdapter = new InventoryTableAdapter();
            AutoLotDataSet.InventoryDataTable data = tableAdapter.GetData();

            PrintAllCarIDs(data);
            ShowRedCars(data);
            BuildDataTableFromQuery(data);

            Console.ReadLine();
        }

        static void PrintAllCarIDs(DataTable data)
        {
            // Получить перечислимую версию DataTable.
            EnumerableRowCollection enumData = data.AsEnumerable();

            // Вывести значения идентификаторов автомобилей.
            foreach (DataRow r in enumData)
            {
                Console.WriteLine($"Car ID = {r["CarID"]}");
            }

            Console.WriteLine();
        }

        static void ShowRedCars(DataTable data)
        {
            // Спроецировать новый результирующий набор, содержащий идентификатор / цвет для строк, в которых Color == Чёрный.
            var cars = from car in data.AsEnumerable()
                       where car.Field<string>("Color") == "Чёрный"
                       select new
                       {
                           ID = car.Field<int>("CarID"),
                           Make = car.Field<string>("Make")
                       };


            Console.WriteLine("Вот чёрные автомобили, которые у нас есть в наличии:");
            foreach (var item in cars)
            {
                Console.WriteLine($"-> CarID = {item.ID} - это {item.Make}");
            }
            Console.WriteLine();
        }

        static void BuildDataTableFromQuery(DataTable data)
        {
            var cars = from car in data.AsEnumerable()
                       where car.Field<int>("CarID") > 5
                       select car;

            // Использовать этот результирующий набор для построения нового объекта DataTable.
            DataTable newTable = cars.CopyToDataTable();

            // Вывести содержимое DataTable.
            for (int curRow = 0; curRow < newTable.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < newTable.Columns.Count; curCol++)
                {
                    Console.Write($"{newTable.Rows[curRow][curCol].ToString().Trim()}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
