using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Monitor.Infrastructure.Configurations.EFCore;

namespace Monitor.Infrastructure.Configurations.EFCore
{
    public class MonitorContextFactory : IDesignTimeDbContextFactory<MonitorDbContext>
    {
        public MonitorDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MonitorDbContext>();
            // @"Server=LAPTOP-EBCC42AV;Initial Catalog=Monitor;Integrated Security=True;"
            // Get the connection from the first argument.
            optionsBuilder.UseSqlServer(args[0]);

            return new MonitorDbContext(optionsBuilder.Options);
        }
    }
}
