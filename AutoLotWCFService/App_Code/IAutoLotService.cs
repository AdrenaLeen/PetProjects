using System.Runtime.Serialization;
using System.ServiceModel;

[ServiceContract]
public interface IAutoLotService
{
	[OperationContract]
    void InsertCar(int id, string make, string color, string petname);

    [OperationContract(Name = "InsertCarWithDetails")]
    void InsertCar(InventoryRecord car);

    [OperationContract]
    InventoryRecord[] GetInventory();
}

[DataContract]
public class InventoryRecord
{
    [DataMember]
    public int ID;

    [DataMember]
    public string Make;

    [DataMember]
    public string Color;

    [DataMember]
    public string PetName;
}
