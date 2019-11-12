using AutoLotDALCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace AutoLotDALCore.EF
{
    public class AutoLotContext : DbContext
    {
        internal AutoLotContext() { }

        public AutoLotContext(DbContextOptions options) : base(options) { }

        public DbSet<CreditRisk> CreditRisks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }

        public string GetTableName(Type type) => Model.FindEntityType(type).SqlServer().TableName;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = @"server=.\SQLEXPRESS;database=AutoLotCore;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
                optionsBuilder.UseSqlServer(
                    connectionString,
                    options => options.EnableRetryOnFailure())
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Создать индекс, который включает несколько столбцов.
            modelBuilder.Entity<CreditRisk>(entity =>
            {
                entity.HasIndex(e => new { e.FirstName, e.LastName }).IsUnique();
            });

            // Установить параметр каскадирования на отношении.
            modelBuilder.Entity<Order>()
                .HasOne(e => e.Car)
                .WithMany(e => e.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
