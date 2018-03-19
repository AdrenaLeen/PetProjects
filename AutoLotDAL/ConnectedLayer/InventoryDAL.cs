using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AutoLotDAL.Models;

namespace AutoLotDAL.ConnectedLayer
{
    public class InventoryDAL
    {
        // Этот член будет использоваться всеми методами.
        private SqlConnection sqlConnection = null;

        public void OpenConnection(string connectionString)
        {
            sqlConnection = new SqlConnection { ConnectionString = connectionString };
            sqlConnection.Open();
        }

        public void CloseConnection()
        {
            sqlConnection.Close();
        }

        public void InsertAuto(string color, string make, string petName)
        {
            // Сформировать и выполнить оператор SQL.
            string sql = $"Insert Into Inventory (Make, Color, PetName) Values ('{make}', '{color}', '{petName}')";

            // Выполнить, используя наше подключение.
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void InsertAuto(NewCar car)
        {
            // Сформатировать и выполнить оператор SQL.
            string sql = $"Insert Into Inventory (Make, Color, PetName) Values ('{car.Make}', '{car.Color}', '{car.PetName}')";

            // Выполнить, используя наше подключение.
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
