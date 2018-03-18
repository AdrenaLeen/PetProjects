using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AutoLotDataReader
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Data Reader *****");

            // Создать и открыть подключение.
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AutoLot;Integrated Security=True;";
                connection.Open();

                // Создать объект команды SQL.
                string sql = "Select * From Inventory";
                SqlCommand myCommand = new SqlCommand(sql, connection);

                // Подключить объект чтения данных с помощью ExecuteReader().
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    // Пройти в цикле по результатам.
                    while (myDataReader.Read())
                    {
                        Console.WriteLine($"-> Производитель: {myDataReader["Make"]}, Дружественное имя: {myDataReader["PetName"]}, Цвет: {myDataReader["Color"]}.");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
