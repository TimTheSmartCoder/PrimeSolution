using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Monitor.Infrastructure.Configurations.EFCore;

namespace Monitor.Infrastructure.Configurations
{
    public class MonitorContextFactory : IDesignTimeDbContextFactory<MonitorDbContext>
    {
        public MonitorDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MonitorDbContext>();
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-EBCC42AV;Initial Catalog=Monitor;Integrated Security=True;");

            return new MonitorDbContext(optionsBuilder.Options);
        }
    }
}
