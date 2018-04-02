using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.DataSets;
using AutoLotDAL.DataSets.AutoLotDataSetTableAdapters;
using System.Data;

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
    }
}
