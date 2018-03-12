using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Monitor.Infrastructure.Configurations.EFCore
{
    public class MonitorContextFactory : IDesignTimeDbContextFactory<MonitorDbContext>
    {
        public MonitorDbContext CreateDbContext(string[] args)
        {
            // Create configuartion object and get connection string.
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string from the appsettings configuration.
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<MonitorDbContext>();
            
            // Get the connection from the first argument.
            optionsBuilder.UseSqlServer(connectionString);

            return new MonitorDbContext(optionsBuilder.Options);
        }
    }
}
