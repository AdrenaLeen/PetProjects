using AutoLot.DAL.Models;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace AutoLot.DAL.DataOperations
{
    public class InventoryDal(string connectionString)
    {
        private NpgsqlConnection? _sqlConnection = null;
        private readonly string _connectionString = connectionString;

        public InventoryDal() : this("Host=localhost;Port=5432;Database=Autolot;Username=postgres;Password=Alias4.7")
        {
        }

        bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing) _sqlConnection?.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void OpenConnection()
        {
            _sqlConnection = new NpgsqlConnection { ConnectionString = _connectionString };
            _sqlConnection.Open();
        }

        private void CloseConnection()
        {
            if (_sqlConnection?.State != ConnectionState.Closed) _sqlConnection?.Close();
        }

        public List<CarViewModel> GetAllInventory()
        {
            OpenConnection();

            // Здесь будут храниться записи.
            List<CarViewModel> inventory = [];

            // Подготовить объект команды.
            string sql = "SELECT i.\"Id\", i.\"Color\", i.\"PetName\", m.\"Name\" as \"Make\" FROM \"Inventory\" i INNER JOIN \"Makes\" m on m.\"Id\" = i.\"MakeId\"";
            using var command = new NpgsqlCommand(sql, _sqlConnection) { CommandType = CommandType.Text };
            NpgsqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                inventory.Add(new CarViewModel
                {
                    Id = (int)dataReader["Id"],
                    Color = (string)dataReader["Color"],
                    Make = (string)dataReader["Make"],
                    PetName = (string)dataReader["PetName"]
                });
            }
            dataReader.Close();
            return inventory;
        }

        public CarViewModel? GetCar(int id)
        {
            OpenConnection();
            CarViewModel? car = null;
            var param = new NpgsqlParameter
            {
                ParameterName = "@\"carId\"",
                Value = id,
                NpgsqlDbType = NpgsqlDbType.Integer,
                Direction = ParameterDirection.Input
            };
            string sql =
                @"SELECT i.""Id"", i.""Color"", i.""PetName"", m.""Name"" as ""Make""
                  FROM ""Inventory"" i
                  INNER JOIN ""Makes"" m on m.""Id"" = i.""MakeId""
                  WHERE i.""Id"" = @""carId""";
            using var command = new NpgsqlCommand(sql, _sqlConnection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(param);
            NpgsqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                car = new CarViewModel
                {
                    Id = (int)dataReader["Id"],
                    Color = (string)dataReader["Color"],
                    Make = (string)dataReader["Make"],
                    PetName = (string)dataReader["PetName"]
                };
            }
            dataReader.Close();
            return car;
        }

        public void InsertAutoNoParams(Car car)
        {
            OpenConnection();

            // Format and execute SQL statement.
            string sql = "Insert Into Inventory (MakeId, Color, PetName) Values " +
                         $"('{car.MakeId}', '{car.Color}', '{car.PetName}')";

            // Execute using our connection.
            using (var command = new NpgsqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public void InsertAuto(Car car)
        {
            OpenConnection();

            // Обратите внимание на "заполнители" в запросе SQL.
            string sql = "INSERT INTO \"Inventory\" (MakeId, Color, PetName) VALUES (@MakeId, @Color, @PetName)";

            // Эта команда будет иметь внутренние параметры.
            using var command = new NpgsqlCommand(sql, _sqlConnection);

            // Заполнить коллекцию параметров.
            var parameter = new NpgsqlParameter
            {
                ParameterName = "@MakeId",
                Value = car.MakeId,
                NpgsqlDbType = NpgsqlDbType.Integer,
                Direction = ParameterDirection.Input
            };
            command.Parameters.Add(parameter);

            parameter = new NpgsqlParameter
            {
                ParameterName = "@Color",
                Value = car.Color,
                NpgsqlDbType = NpgsqlDbType.Varchar,
                Size = 50,
                Direction = ParameterDirection.Input
            };
            command.Parameters.Add(parameter);

            parameter = new NpgsqlParameter
            {
                ParameterName = "@PetName",
                Value = car.PetName,
                NpgsqlDbType = NpgsqlDbType.Varchar,
                Size = 50,
                Direction = ParameterDirection.Input
            };
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void DeleteCar(int id)
        {
            OpenConnection();

            // Получить идентификатор автомобиля, подлежащего удалению, и удалить запись о нем.
            var param = new NpgsqlParameter
            {
                ParameterName = "@\"carId\"",
                Value = id,
                NpgsqlDbType = NpgsqlDbType.Integer,
                Direction = ParameterDirection.Input
            };
            string sql = "DELETE FROM \"Inventory\" WHERE \"Id\" = @\"carId\"";
            using (var command = new NpgsqlCommand(sql, _sqlConnection))
            {
                command.Parameters.Add(param);
                try
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (NpgsqlException ex)
                {
                    var error = new Exception("Этот автомобиль заказан!", ex);
                    throw error;
                }
            }

            CloseConnection();
        }

        public void UpdateCarPetName(int id, string newPetName)
        {
            OpenConnection();

            // Получить идентификатор автомобиля для модификации дружеского имени.
            var paramId = new NpgsqlParameter
            {
                ParameterName = "@\"carId\"",
                Value = id,
                NpgsqlDbType = NpgsqlDbType.Integer,
                Direction = ParameterDirection.Input
            };
            var paramName = new NpgsqlParameter
            {
                ParameterName = "@\"petName\"",
                Value = newPetName,
                NpgsqlDbType = NpgsqlDbType.Varchar,
                Size = 50,
                Direction = ParameterDirection.Input
            };
            string sql = $"UPDATE \"Inventory\" SET \"PetName\" = '{newPetName}' WHERE \"Id\" = '{id}'";
            using (var command = new NpgsqlCommand(sql, _sqlConnection))
            {
                command.Parameters.Add(paramId);
                command.Parameters.Add(paramName);
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public string? LookUpPetName(int carId)
        {
            OpenConnection();
            string? carPetName;

            // Установить имя хранимой процедуры.
            using (var command = new NpgsqlCommand("GetPetName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Входной параметр.
                var param = new NpgsqlParameter
                {
                    ParameterName = "@carId",
                    NpgsqlDbType = NpgsqlDbType.Integer,
                    Value = carId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(param);

                // Выходной параметр.
                param = new NpgsqlParameter
                {
                    ParameterName = "@petName",
                    NpgsqlDbType = NpgsqlDbType.Varchar,
                    Size = 50,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(param);

                // Выполнить хранимую процедуру.
                command.ExecuteNonQuery();

                // Возвратить выходной параметр.
                carPetName = (string?)command.Parameters["@petName"].Value;
                CloseConnection();
            }

            return carPetName;
        }

        public void ProcessCreditRisk(bool throwEx, int customerId)
        {
            OpenConnection();

            // First, look up current name based on customer ID.
            string fName;
            string lName;
            var cmdSelect =
                new NpgsqlCommand("Select * from Customers where Id = @customerId",
                    _sqlConnection);
            var paramId = new NpgsqlParameter
            {
                ParameterName = "@customerId",
                NpgsqlDbType = NpgsqlDbType.Integer,
                Value = customerId,
                Direction = ParameterDirection.Input
            };
            cmdSelect.Parameters.Add(paramId);
            using (var dataReader = cmdSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();

                    fName = (string)dataReader["FirstName"];
                    lName = (string)dataReader["LastName"];
                }
                else
                {
                    CloseConnection();
                    return;
                }
            }

            cmdSelect.Parameters.Clear();

            // Create command objects that represent each step of the operation.
            var cmdUpdate =
                new NpgsqlCommand("Update Customers set LastName = LastName + ' (CreditRisk) ' where Id = @customerId",
                    _sqlConnection);
            cmdUpdate.Parameters.Add(paramId);
            var cmdInsert =
                new NpgsqlCommand(
                    "Insert Into CreditRisks (CustomerId, FirstName, LastName) Values(@CustomerId,@FirstName, @LastName)",
                    _sqlConnection);
            var parameterId2 = new NpgsqlParameter
            {
                ParameterName = "@CustomerId",
                NpgsqlDbType = NpgsqlDbType.Integer,
                Value = customerId,
                Direction = ParameterDirection.Input
            };
            var parameterFirstName = new NpgsqlParameter
            {
                ParameterName = "@FirstName",
                Value = fName,
                NpgsqlDbType = NpgsqlDbType.Varchar,
                Size = 50,
                Direction = ParameterDirection.Input
            };

            var parameterLastName = new NpgsqlParameter
            {
                ParameterName = "@LastName",
                Value = lName,
                NpgsqlDbType = NpgsqlDbType.Varchar,
                Size = 50,
                Direction = ParameterDirection.Input
            };

            cmdInsert.Parameters.Add(parameterId2);
            cmdInsert.Parameters.Add(parameterFirstName);
            cmdInsert.Parameters.Add(parameterLastName);

            // We will get this from the connection object.
            NpgsqlTransaction? tx = null;
            try
            {
                tx = _sqlConnection?.BeginTransaction();

                // Enlist the commands into this transaction.
                cmdInsert.Transaction = tx;
                cmdUpdate.Transaction = tx;

                // Execute the commands.
                cmdInsert.ExecuteNonQuery();
                cmdUpdate.ExecuteNonQuery();

                // Simulate error.
                if (throwEx)
                {
                    throw new Exception("Sorry!  Database error! Tx failed...");
                }

                // Commit it!
                tx?.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Any error will roll back transaction.  Using the new conditional access operator to check for null.
                tx?.Rollback();
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}