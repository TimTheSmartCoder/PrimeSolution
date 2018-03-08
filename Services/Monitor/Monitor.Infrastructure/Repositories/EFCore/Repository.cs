using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Monitor.Infrastructure.Repositories.EFCore
{
    public class Repository
        : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            this.dbContext = dbContext;
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            EntityEntry<TEntity> entry = this.dbContext
                .Set<TEntity>().Add(entity);

            return entry.Entity;
        }
    }
}
