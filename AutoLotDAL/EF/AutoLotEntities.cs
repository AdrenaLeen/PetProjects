namespace AutoLotDAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using AutoLotDAL.Models;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.Interception;
    using AutoLotDAL.Interception;
    using System.Data.Entity.Core.Objects;

    public class AutoLotEntities : DbContext
    {
        public AutoLotEntities() : base("name=AutoLotConnection")
        {
            // Код перехватчика.
            ObjectContext context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += OnObjectMaterialized;
            context.SavingChanges += OnSavingChanges;
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        private void OnSavingChanges(object sender, EventArgs eventArgs)
        {
            // Параметр sender имеет тип ObjectContext. Можно получать текущие и исходные значения, а также отменять / модифицировать операцию сохранения любым желаемым образом.
            ObjectContext context = sender as ObjectContext;
            if (context == null) return;
            foreach (ObjectStateEntry item in context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Added))
            {
                // Делать здесь что-то важное.
                if ((item.Entity as Inventory) != null)
                {
                    Inventory entity = (Inventory)item.Entity;
                    if (entity.Color == "Красный") item.RejectPropertyChanges(nameof(entity.Color));
                }
            }
        }

        private void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
        }
    }
}