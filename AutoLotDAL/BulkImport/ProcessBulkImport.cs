using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AutoLotDAL.BulkImport
{
    public static class ProcessBulkImport
    {
        private static SqlConnection sqlConnection = null;

        private static readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AutoLot;Integrated Security=True;";

        private static void OpenConnection()
        {
            sqlConnection = new SqlConnection { ConnectionString = connectionString };
            sqlConnection.Open();
        }

        private static void CloseConnection()
        {
            if (sqlConnection?.State != ConnectionState.Closed) sqlConnection?.Close();
        }

        public static void ExecuteBulkImport<T>(IEnumerable<T> records, string tableName)
        {
            OpenConnection();
            using (SqlConnection conn = sqlConnection)
            {
                SqlBulkCopy bc = new SqlBulkCopy(conn)
                {
                    DestinationTableName = tableName
                };
                MyDataReader<T> dataReader = new MyDataReader<T>(records.ToList());
                try
                {
                    bc.WriteToServer(dataReader);
                }
                catch (Exception)
                {
                    // Здесь должно что-то делаться.
                }
                finally
                {
                    CloseConnection();
                    bc.Close();
                    dataReader.Close();
                }
            }
        }
    }
}
