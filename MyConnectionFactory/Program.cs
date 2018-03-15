using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Configuration;

namespace MyConnectionFactory
{
    // Список возможных поставщиков.
    enum DataProvider { SqlServer, OleDb, Odbc, None }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("**** Очень простая фабрика подключений *****");

            // Прочитать ключ provider.
            string dataProviderString = ConfigurationManager.AppSettings["provider"];

            // Преобразовать строку в перечисление.
            DataProvider dataProvider = DataProvider.None;
            if (Enum.IsDefined(typeof(DataProvider), dataProviderString))
            {
                dataProvider = (DataProvider)Enum.Parse(typeof(DataProvider), dataProviderString);
            }
            else
            {
                Console.WriteLine("Поставщики отсутствуют!");
                Console.ReadLine();
                return;
            }

            // Получить конкретное подключение.
            IDbConnection myConnection = GetConnection(dataProvider);
            Console.WriteLine($"Ваше подключение: {myConnection?.GetType().Name ?? "неизвестный тип"}");
            
            // Открыть, использовать и закрыть подключение...
            Console.ReadLine();
        }

        // Этот метод возвращает конкретный объект подключения на основе значения перечисления DataProvider.
        static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection connection = null;
            switch (dataProvider)
            {
                case DataProvider.SqlServer:
                    connection = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    connection = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    connection = new OdbcConnection();
                    break;
                default:
                    return null;
            }
            return connection;
        }
    }
}
