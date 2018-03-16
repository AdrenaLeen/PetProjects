using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataProviderFactory
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Фабрика поставщиков данных *****");

            // Получить строку подключения и поставщик из файла *.config.
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            // Получить фабрику поставщиков.
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            // Получить объект подключения.
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    ShowError("Connection");
                    return;
                }
                Console.WriteLine($"Ваш объект подключения: {connection.GetType().Name}");
                connection.ConnectionString = connectionString;
                connection.Open();

                SqlConnection sqlConnection = connection as SqlConnection;
                if (sqlConnection != null)
                {
                    // Вывести информацию об используемой версии SQL Server.
                    Console.WriteLine(sqlConnection.ServerVersion);
                }

                // Создать объект команды.
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    ShowError("Command");
                    return;
                }
                Console.WriteLine($"Ваш объект команды: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * From Inventory";

                // Вывести данные с помощью объекта чтения данных.
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    Console.WriteLine($"Ваш объект чтения данных: {dataReader.GetType().Name}");
                    Console.WriteLine("***** Inventory *****");
                    while (dataReader.Read()) Console.WriteLine($"-> Машина #{dataReader["CarId"]} - это {dataReader["Make"]}.");
                }
            }
            Console.ReadLine();
        }

        private static void ShowError(string objectName)
        {
            Console.WriteLine($"Возникла проблема с созданием объекта {objectName}");
            Console.ReadLine();
        }
    }
}
