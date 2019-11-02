using AutoLotDAL.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AutoLotDAL.Repos
{
    public class InventoryRepo : BaseRepo<Inventory>, IRepo<Inventory>
    {
        public InventoryRepo() => Table = Context.Inventory;

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new Inventory() { CarId = id, Timestamp = timeStamp }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id, byte[] timeStamp)
        {
            Context.Entry(new Inventory() { CarId = id, Timestamp = timeStamp }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
