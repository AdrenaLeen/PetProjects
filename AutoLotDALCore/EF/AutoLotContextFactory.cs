using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AutoLotDALCore.EF
{
    public class AutoLotContextFactory : IDesignTimeDbContextFactory<AutoLotContext>
    {
        public AutoLotContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AutoLotContext> optionsBuilder = new DbContextOptionsBuilder<AutoLotContext>();
            string connectionString = @"server=.\SQLEXPRESS;database=AutoLotCore;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            optionsBuilder.UseSqlServer(
                    connectionString,
                    options => options.EnableRetryOnFailure())
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            return new AutoLotContext(optionsBuilder.Options);
        }
    }
}
