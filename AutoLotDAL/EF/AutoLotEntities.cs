namespace AutoLotDAL.EF
{
    using AutoLotDAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;

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
            if (!(sender is ObjectContext context)) return;
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
            if (e.Entity is EntityBase model) model.IsChanged = false;
        }
    }
}