using Microsoft.EntityFrameworkCore;

namespace DotConnectOracle.CastError.Sample.Contexts
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            var connectionString = "<DatabaseConnectionString>";
            var licenseKey = "<dotConnectOracleLicense>";
            optionsBuilder.UseOracle($"{connectionString}; License Key={licenseKey}; Direct=True");
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}