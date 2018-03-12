using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Monitor.Infrastructure.Configurations.EFCore;

namespace Monitor.Infrastructure.Repositories.EFCore
{
    public class UnitOfWork
        : IUnitOfWork
    {
        private readonly MonitorDbContext dbContext;

        public UnitOfWork(MonitorDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            this.dbContext = dbContext;

            // Create generic repository.
            this.Repository = new Repository(this.dbContext);
        }

        public IRepository Repository { get; }

        public async Task<bool> SaveChanges(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
