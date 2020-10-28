using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FillDataSetUsingSqlDataAdapter
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Адаптеры данных *****");

            // Жёстко закодированная строка подключения.
            string connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            // Объект DataSet создаётся вызывающим кодом.
            DataSet ds = new DataSet("AutoLot");

            // Указать адаптеру текст команды Select и строку подключения.
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Inventory", connectionString);

            // Отобразить имена слолбцов базы данных на дружественные к пользователю имена.
            DataTableMapping tableMapping = adapter.TableMappings.Add("Inventory", "Current Inventory");
            tableMapping.ColumnMappings.Add("CarId", "Car Id");
            tableMapping.ColumnMappings.Add("PetName", "Name of Car");

            // Заполнить DataSet новой таблицей по имени Inventory.
            adapter.Fill(ds, "Inventory");

            // Отобразить содержимое DataSet.
            PrintDataSet(ds);

            Console.ReadLine();
        }

        private static void PrintDataSet(DataSet ds)
        {
            // Вывести имя DataSet и любые расширенные свойства.
            Console.WriteLine($"Имя DataSet: {ds.DataSetName}");
            foreach (DictionaryEntry de in ds.ExtendedProperties) Console.WriteLine($"Ключ = {de.Key}, Значение = {de.Value}");
            Console.WriteLine();
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine($"=> Таблица {dt.TableName}:");

                // Вывести имена столбцов.
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++) Console.Write($"{dt.Columns[curCol].ColumnName}\t");
                Console.WriteLine();
                Console.WriteLine("----------------------------------");

                // Вывести содержимое DataTable.
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        Console.Write($"{dt.Rows[curRow][curCol].ToString().Trim()}\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
