using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Monitor.Infrastructure.Configurations.EFCore
{
    public class MonitorDbContext
        : DbContext
    {
        public MonitorDbContext(DbContextOptions<MonitorDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
