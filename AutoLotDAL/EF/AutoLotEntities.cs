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
        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
            DbInterception.Add(new ConsoleWriterInterceptor());
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}