using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AutoLotDAL.DisconnectedLayer
{
    public class InventoryDALDC
    {
        // Поля данных.
        private string connectionString;
        private SqlDataAdapter adapter = null;

        public InventoryDALDC(string connStr)
        {
            connectionString = connStr;

            // Конфигурировать объект SqlDataAdapter.
            ConfigureAdapter(out adapter);
        }

        private void ConfigureAdapter(out SqlDataAdapter adapter)
        {
            throw new NotImplementedException();
        }
    }
}
