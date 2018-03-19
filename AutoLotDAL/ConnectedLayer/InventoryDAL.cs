using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        public void DeleteCar(int id)
        {
            // Удалить запись об автомобиле с указанным CarId.
            string sql = $"Delete from Inventory where CarId = '{id}'";
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Извините! Эта машина заказана!", ex);
                    throw error;
                }
            }
        }

        public void UpdateCarPetName(int id, string newPetName)
        {
            // Обновить PetName в записи об автомобиле с казанным CarId.
            string sql = $"Update Inventory Set PetName = '{newPetName}' Where CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<NewCar> GetAllInventoryAsList()
        {
            // Здесь будут храниться записи.
            List<NewCar> inv = new List<NewCar>();

            // Подготовить объект команды.
            string sql = "Select * From Inventory";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    inv.Add(new NewCar
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    });
                }
                dataReader.Close();
            }
            return inv;
        }

        public DataTable GetAllInventoryAsDataTable()
        {
            // Здесь будут храниться записи.
            DataTable dataTable = new DataTable();

            // Подготовить объект команды.
            string sql = "Select * From Inventory";
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                SqlDataReader dataReader = cmd.ExecuteReader();

                // Заполнить DataTable данными из объекта чтения и выполнить очистку.
                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;
        }
    }
}
