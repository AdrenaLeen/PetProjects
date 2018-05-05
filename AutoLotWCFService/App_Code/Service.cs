using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени класса "Service" в коде, SVC-файле и файле конфигурации.
public class Service : IAutoLotService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

    public InventoryRecord[] GetInventory()
    {
        throw new NotImplementedException();
    }

    public void InsertCar(int id, string make, string color, string petname)
    {
        throw new NotImplementedException();
    }

    public void InsertCar(InventoryRecord car)
    {
        throw new NotImplementedException();
    }
}
