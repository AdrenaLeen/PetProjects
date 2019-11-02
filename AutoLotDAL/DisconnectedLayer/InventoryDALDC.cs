using System.Data;
using System.Data.SqlClient;

namespace AutoLotDAL.DisconnectedLayer
{
    public class InventoryDALDC
    {
        // Поля данных.
        private readonly string connectionString;
        private readonly SqlDataAdapter adapter = null;

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
            using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter)) { }
        }

        public DataTable GetAllInventory()
        {
            DataTable inv = new DataTable("Inventory");
            adapter.Fill(inv);
            return inv;
        }

        public void UpdateInventory(DataTable modifiedTable) => adapter.Update(modifiedTable);
    }
}
