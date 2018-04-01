using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.DataSets;
using AutoLotDAL.DataSets.AutoLotDataSetTableAdapters;

namespace StronglyTypedDataSetConsoleClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Строго типизированные DataSet *****");

            // Вызываемый код создаёт объект DataSet.
            AutoLotDataSet.InventoryDataTable table = new AutoLotDataSet.InventoryDataTable();

            // Информировать адаптер о команде Select и подключении.
            InventoryTableAdapter adapter = new InventoryTableAdapter();

            // Заполнить объект DataSet новой таблицей по имени Inventory.
            adapter.Fill(table);
            PrintInventory(table);

            // Добавить строки, обновить и вывести повторно.
            AddRecords(table, adapter);
            table.Clear();
            adapter.Fill(table);
            PrintInventory(table);
            Console.WriteLine();

            Console.ReadLine();
        }

        static void PrintInventory(AutoLotDataSet.InventoryDataTable dt)
        {
            // Вывести имена столбцов.
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.Write($"{dt.Columns[curCol].ColumnName}\t");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            // Вывести содержимое DataTable.
            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write($"{dt.Rows[curRow][curCol]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void AddRecords(AutoLotDataSet.InventoryDataTable table, InventoryTableAdapter adapter)
        {
            try
            {
                // Получить из таблицы новую строго типизированную строку.
                AutoLotDataSet.InventoryRow newRow = table.NewInventoryRow();

                // Заполнить строку данными.
                newRow.Color = "Фиолетовый";
                newRow.Make = "BMW";
                newRow.PetName = "Саку";

                // Вставить новую строку.
                table.AddInventoryRow(newRow);

                // Добавить ещё одну строку, используя перегруженный метод добавления.
                table.AddInventoryRow("Yugo", "Зелёный", "Живчик");

                // Обновить базу данных.
                adapter.Update(table);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
