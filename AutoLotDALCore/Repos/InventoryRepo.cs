using AutoLotDALCore.EF;
using AutoLotDALCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AutoLotDALCore.Repos
{
    public class InventoryRepo : BaseRepo<Inventory>, IInventoryRepo
    {
        public InventoryRepo(AutoLotContext context) : base(context) { }

        public override List<Inventory> GetAll() => GetAll(x => x.PetName, true).ToList();

        public List<Inventory> GetPinkCars() => GetSome(x => x.Color == "Pink");

        public List<Inventory> Search(string searchString) => Context.Cars.Where(c => Microsoft.EntityFrameworkCore.EF.Functions.Like(c.PetName, $"%{searchString}%")).ToList();

        public List<Inventory> GetRelatedData() => Context.Cars.FromSql("SELECT * FROM Inventory").Include(x => x.Orders).ThenInclude(x => x.Customer).ToList();
    }
}
