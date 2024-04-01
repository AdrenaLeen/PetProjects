using AutoLot.Samples.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Samples
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            SavingChanges += (sender, args) =>
            {
                string connString = string.Empty;
                if (sender != null) connString = ((DbContext)sender).Database.GetConnectionString() ?? string.Empty;
                Console.WriteLine($"Сохранение изменений для {connString}");
            };

            SavedChanges += (sender, args) => { Console.WriteLine($"Сохранено {args.EntitiesSavedCount} сущностей"); };

            SaveChangesFailed += (sender, args) =>
            {
                // Сгенерировано исключение
                Console.WriteLine($"Возникло исключение! {args.Exception.Message}");
            };
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Radio> Radios { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Обращения к Fluent API.
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Inventory", "public");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.MakeId, "IX_Inventory_MakeId");
                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.PetName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.DateBuilt).HasDefaultValueSql("now()");
                entity.Property(e => e.IsDriveable)
                    .HasField("_isDriveable")
                    .HasDefaultValue(true);
                entity.Property(e => e.DisplayName)
                    .HasComputedColumnSql(@"""PetName"" || ' (' || ""Color"" || ')'", stored: true);
            });

            modelBuilder.Entity<Make>(entity =>
            {
                entity.HasMany(e => e.Cars)
                    .WithOne(c => c.MakeNavigation)
                    .HasForeignKey(c => c.MakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Makes_MakeId");
            });

            modelBuilder.Entity<Radio>(entity =>
            {
                entity.HasIndex(e => e.CarId, "IX_Radios_CarId")
                    .IsUnique();
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasOne(d => d.RadioNavigation)
                    .WithOne(p => p.CarNavigation)
                    .HasForeignKey<Radio>(d => d.CarId);
            });

            modelBuilder.Entity<Car>()
                .HasMany(p => p.Drivers)
                .WithMany(p => p.Cars)
                .UsingEntity<Dictionary<string, object>>(
                    "CarDriver",
                    j => j
                        .HasOne<Driver>()
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .HasConstraintName("FK_CarDriver_Drivers_DrvierId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Car>()
                        .WithMany()
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK_CarDriver_Cars_CarId")
                        .OnDelete(DeleteBehavior.ClientCascade));

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
