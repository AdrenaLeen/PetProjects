using AutoLotDAL.DataSets;
using AutoLotDAL.DataSets.AutoLotDataSetTableAdapters;
using System;

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

            RemoveRecords(table, adapter);
            table.Clear();
            adapter.Fill(table);
            PrintInventory(table);

            CallStoredProc();

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

        private static void RemoveRecords(AutoLotDataSet.InventoryDataTable table, InventoryTableAdapter adapter)
        {
            try
            {
                AutoLotDataSet.InventoryRow rowToDelete = table.FindByCarId(8);
                adapter.Delete(rowToDelete.CarId, rowToDelete.Make, rowToDelete.Color, rowToDelete.PetName);
                rowToDelete = table.FindByCarId(9);
                adapter.Delete(rowToDelete.CarId, rowToDelete.Make, rowToDelete.Color, rowToDelete.PetName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CallStoredProc()
        {
            try
            {
                QueriesTableAdapter queriesTableAdapter = new QueriesTableAdapter();
                Console.Write("Введите ID автомобиля для поиска: ");
                string carID = Console.ReadLine() ?? "0";
                string carName = "";
                queriesTableAdapter.GetPetName(int.Parse(carID), ref carName);
                Console.WriteLine($"У CarID {carID} имя {carName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
