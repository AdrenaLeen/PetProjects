namespace AutoLotDAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using AutoLotDAL.Models;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.Interception;
    using AutoLotDAL.Interception;

    public class AutoLotEntities : DbContext
    {
        static readonly DatabaseLogger databaseLogger = new DatabaseLogger("sqllog.txt", true);

        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
            databaseLogger.StartLogging();
            DbInterception.Add(databaseLogger);
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(databaseLogger);
            databaseLogger.StopLogging();
            base.Dispose(disposing);
        }
    }
}