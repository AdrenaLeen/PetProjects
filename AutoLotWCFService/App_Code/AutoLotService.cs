using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AutoLotDAL.ConnectedLayer;
using System.Data;
using System.Configuration;

public class AutoLotService : IAutoLotService
{
    private string ConnString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ToString();

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
            InventoryRecord r = new InventoryRecord();
            r.ID = (int)reader["CarID"];
            r.Color = ((string)reader["Color"]);
            r.Make = ((string)reader["Make"]);
            r.PetName = ((string)reader["PetName"]);
            records.Add(r);
        }

        // Трансформировать List<T> в массив элементов типа InventoryRecord.
        return records.ToArray();
    }
}
