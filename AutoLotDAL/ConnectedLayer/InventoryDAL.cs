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
            // "Заполнители" в запросе SQL.
            string sql = "Insert Into Inventory (Make, Color, PetName) Values (@Make, @Color, @PetName)";

            // Эта команда будет иметь внутренние параметры.
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                // Заполнить коллекцию параметров.
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Make",
                    Value = make,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Color",
                    Value = color,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@PetName",
                    Value = petName,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

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

        public string LookUpPetName(int carId)
        {
            string carPetName;

            // Установить имя хранимой процедуры.
            using (SqlCommand command = new SqlCommand("GetPetName", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Входной параметр.
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@carId",
                    SqlDbType = SqlDbType.Int,
                    Value = carId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(param);

                // Выходной параметр.
                param = new SqlParameter
                {
                    ParameterName = "@petName",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(param);

                // Выполнить хранимую процедуру.
                command.ExecuteNonQuery();

                // Возвратить выходной параметр.
                carPetName = (string)command.Parameters["@petName"].Value;
            }
            return carPetName;
        }

        public void ProcessCreditRisk(bool throwEx, int custId)
        {
            // Первым делом найти текущее имя по идентификатору клиента.
            string fName;
            string lName;
            SqlCommand cmdSelect = new SqlCommand($"Select * from Customers where CustId = {custId}", sqlConnection);
            using (SqlDataReader dataReader = cmdSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    fName = (string)dataReader["FirstName"];
                    lName = (string)dataReader["LastName"];
                }
                else
                {
                    return;
                }
            }

            // Создать объекты команд, которые представляют каждый шаг операции.
            SqlCommand cmdRemove = new SqlCommand($"Delete from Customers where CustId = {custId}", sqlConnection);
            SqlCommand cmdInsert = new SqlCommand($"Insert Into CreditRisks (FirstName, LastName) Values('{fName}', '{lName}')", sqlConnection);

            // Это будет получено из объекта подключения.
            SqlTransaction tx = null;
            try
            {
                tx = sqlConnection.BeginTransaction();

                // Включить команды в транзакцию.
                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;

                // Выполнить команды.
                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();

                // Эмулировать ошибку.
                if (throwEx)
                {
                    throw new Exception("Извините! Ошибка базы данных! Транзакция не выполнена...");
                }

                // Зафиксировать транзакцию.
                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Любая ошибка приведёт к откату транзакции.
                // Использование новой условной операции для проверки на предмет null.
                tx?.Rollback();
            }
        }
    }
}
