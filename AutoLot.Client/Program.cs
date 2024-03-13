using AutoLot.DAL.DataOperations;
using AutoLot.DAL.Models;

var dal = new InventoryDal();
var list = dal.GetAllInventory();

Console.WriteLine(" ************** Все машины ************** ");
Console.WriteLine("CarId\tMake\tColor\tPet Name");
foreach (CarViewModel itm in list) Console.WriteLine($"{itm.Id}\t{itm.Make}\t{itm.Color}\t{itm.PetName}");
Console.WriteLine();
var car = dal.GetCar(list.OrderBy(x => x.Color).Select(x => x.Id).First());

Console.WriteLine(" ************** Первая машина по цвету ************** ");
Console.WriteLine("CarId\tMake\tColor\tPet Name");
Console.WriteLine($"{car?.Id}\t{car?.Make}\t{car?.Color}\t{car?.PetName}");
try
{
    dal.DeleteCar(5);
    Console.WriteLine("Запись об автомобиле удалена.");
}
catch (Exception ex)
{
    Console.WriteLine($"Возникло исключение: {ex.Message}");
}

dal.InsertAuto(new Car { Color = "Голубой", MakeId = 5, PetName = "TowMonster" });
list = dal.GetAllInventory();
CarViewModel newCar = list.First(x => x.PetName == "TowMonster");
Console.WriteLine(" ************** Новая машина ************** ");
Console.WriteLine("CarId\tMake\tColor\tPet Name");
Console.WriteLine($"{newCar.Id}\t{newCar.Make}\t{newCar.Color}\t{newCar.PetName}");

dal.DeleteCar(newCar.Id);
string? petName = null;
if (car != null) petName = dal.LookUpPetName(car.Id);

Console.WriteLine(" ************** Новая машина ************** ");
Console.WriteLine($"Дружественное имя: {petName}");

FlagCustomer();
Console.ReadLine();

static void FlagCustomer()
{
    Console.WriteLine("***** Простая транзакция *****");

    // Простой способ позволить транзакции успешно завершиться или отказать.
    bool throwEx = true;
    Console.Write("Хотите сгенерировать исключение (Y or N): ");
    var userAnswer = Console.ReadLine();
    if (string.IsNullOrEmpty(userAnswer) || userAnswer.Equals("N", StringComparison.OrdinalIgnoreCase)) throwEx = false;
    var dal = new InventoryDal();

    // Обработать клиента 1 - ввести идентификатор клиента, подлежащего перемещению.
    dal.ProcessCreditRisk(throwEx, 1);
    Console.WriteLine("Результаты ищите в таблице CreditRisk");
    Console.WriteLine();
}