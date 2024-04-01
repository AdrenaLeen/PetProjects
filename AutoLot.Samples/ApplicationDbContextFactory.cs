using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AutoLot.Samples
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = "Host=localhost;Port=5432;Database=Autolot;Username=postgres;Password=Alias4.7";
            optionsBuilder.UseNpgsql(connectionString);
            Console.WriteLine(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}