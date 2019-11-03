using AutoLotDAL.ConnectedLayer;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

public class AutoLotService : IAutoLotService
{
    private readonly string ConnString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ToString();

    public void InsertCar(int id, string make, string color, string petname)
    {
        InventoryDAL d = new InventoryDAL();
        d.OpenConnection(ConnString);
        d.InsertAuto(color, make, petname);
        d.CloseConnection();
    }

    public void InsertCar(InventoryRecord car)
    {
        InventoryDAL d = new InventoryDAL();
        d.OpenConnection(ConnString);
        d.InsertAuto(car.Color, car.Make, car.PetName);
        d.CloseConnection();
    }

    public InventoryRecord[] GetInventory()
    {
        // Сначала получить DataTable из базы данных.
        InventoryDAL d = new InventoryDAL();
        d.OpenConnection(ConnString);
        DataTable dt = d.GetAllInventoryAsDataTable();
        d.CloseConnection();

        // Теперь создать List<T> для хранения записей.
        List<InventoryRecord> records = new List<InventoryRecord>();

        // Скопировать содержимое таблицы данных в список List<> специальных контрактов.
        DataTableReader reader = dt.CreateDataReader();
        while (reader.Read())
        {
            InventoryRecord r = new InventoryRecord
            {
                ID = (int)reader["CarID"],
                Color = (string)reader["Color"],
                Make = (string)reader["Make"],
                PetName = (string)reader["PetName"]
            };
            records.Add(r);
        }

        // Трансформировать List<T> в массив элементов типа InventoryRecord.
        return records.ToArray();
    }
}
