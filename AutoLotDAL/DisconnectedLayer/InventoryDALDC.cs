using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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
            // Создать адаптер и настроить SelectCommand.
            adapter = new SqlDataAdapter("Select * From Inventory", connectionString);

            // Динамически получить остальные объекты команд во время выполнения, используя SqlCommandBuilder.
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        }

        public DataTable GetAllInventory()
        {
            DataTable inv = new DataTable("Inventory");
            adapter.Fill(inv);
            return inv;
        }

        public void UpdateInventory(DataTable modifiedTable)
        {
            adapter.Update(modifiedTable);
        }
    }
}
