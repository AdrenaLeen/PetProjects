using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDAL.ConnectedLayer
{
    public class InventoryDAL
    {
        private readonly string connectionString;

        // Этот член будет использоваться всеми методами.
        private SqlConnection sqlConnection = null;

        public InventoryDAL() : this(@"Data Source=.\SQLEXPRESS;Initial Catalog=AutoLot;Integrated Security=True;") { }

        public InventoryDAL(string connString) => connectionString = connString;

        public void OpenConnection()
        {
            sqlConnection = new SqlConnection { ConnectionString = connectionString };
            sqlConnection.Open();
        }

        public void CloseConnection() => sqlConnection.Close();

        public List<Car> GetAllInventory()
        {
            OpenConnection();

            // Здесь будут храниться записи.
            List<Car> inventory = new List<Car>();

            // Подготовить объект команды.
            string sql = "Select * From Inventory";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    inventory.Add(new Car
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    });
                }
                dataReader.Close();
            }
            return inventory;
        }

        public Car GetCar(int id)
        {
            OpenConnection();
            Car car = null;
            string sql = $"Select * From Inventory where CarId = {id}";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    car = new Car
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    };
                }
                dataReader.Close();
            }
            return car;
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

        public void InsertAuto(Car car)
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
            OpenConnection();
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
            CloseConnection();
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

        public List<Car> GetAllInventoryAsList()
        {
            // Здесь будут храниться записи.
            List<Car> inv = new List<Car>();

            // Подготовить объект команды.
            string sql = "Select * From Inventory";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    inv.Add(new Car
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
            OpenConnection();
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
                CloseConnection();
            }
            return carPetName;
        }

        public void ProcessCreditRisk(bool throwEx, int custId)
        {
            // Первым делом найти текущее имя по идентификатору клиента.
            string fName;
            string lName;
            using (SqlCommand cmdSelect = new SqlCommand($"Select * from Customers where CustId = {custId}", sqlConnection))
            {
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
            }

            // Это будет получено из объекта подключения.
            SqlTransaction tx = null;
            try
            {
                tx = sqlConnection.BeginTransaction();

                // Создать объекты команд, которые представляют каждый шаг операции.
                using (SqlCommand cmdRemove = new SqlCommand($"Delete from Customers where CustId = {custId}", sqlConnection))
                {
                    using (SqlCommand cmdInsert = new SqlCommand($"Insert Into CreditRisks (FirstName, LastName) Values('{fName}', '{lName}')", sqlConnection))
                    {
                        // Включить команды в транзакцию.
                        cmdInsert.Transaction = tx;
                        cmdRemove.Transaction = tx;

                        // Выполнить команды.
                        cmdInsert.ExecuteNonQuery();
                        cmdRemove.ExecuteNonQuery();
                    }
                }

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
