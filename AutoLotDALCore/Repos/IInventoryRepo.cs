using AutoLotDALCore.Models;
using System.Collections.Generic;

namespace AutoLotDALCore.Repos
{
    public interface IInventoryRepo : IRepo<Inventory>
    {
        List<Inventory> Search(string searchString);
        List<Inventory> GetPinkCars();
        List<Inventory> GetRelatedData();
    }
}
