using System;
using System.Data.SqlClient;

namespace AutoLotDataReader
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Data Reader *****");

            // Предположим, что значение connectionString на самом деле получено из файла *.config.
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AutoLot;Integrated Security=True;";

            // Создать строку подключения с помощью объекта построителя.
            SqlConnectionStringBuilder cnStringBuilder = new SqlConnectionStringBuilder(connectionString)
            {
                // Изменить значение таймаута.
                ConnectTimeout = 5
            };

            // Создать и открыть подключение.
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnStringBuilder.ConnectionString;
                connection.Open();

                // Новая вспомогательная функция.
                ShowConnectionStatus(connection);

                // Создать объект команды SQL.
                string sql = "Select * From Inventory;Select * from Customers";
                using (SqlCommand myCommand = new SqlCommand(sql, connection))
                {
                    // Создать ещё один объект команды посредством свойств.
                    using (SqlCommand testCommand = new SqlCommand())
                    {
                        testCommand.Connection = connection;
                        testCommand.CommandText = sql;
                    }

                    // Подключить объект чтения данных с помощью ExecuteReader().
                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {
                        do
                        {
                            // Пройти в цикле по результатам.
                            while (myDataReader.Read())
                            {
                                Console.WriteLine("***** Запись *****");
                                for (int i = 0; i < myDataReader.FieldCount; i++) Console.WriteLine($"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)}");
                                Console.WriteLine();
                            }
                        } while (myDataReader.NextResult());
                    }
                }
            }
            Console.ReadLine();
        }

        static void ShowConnectionStatus(SqlConnection connection)
        {
            // Вывести различные сведения о текущем объекте подключения.
            Console.WriteLine("***** Информация о вашем объекте подключения *****");
            Console.WriteLine($"Местоположение базы данных: {connection.DataSource}");
            Console.WriteLine($"Имя базы данных: {connection.Database}");
            Console.WriteLine($"Таймаут: {connection.ConnectionTimeout}");
            Console.WriteLine($"Состояние: {connection.State}");
            Console.WriteLine();
        }
    }
}
