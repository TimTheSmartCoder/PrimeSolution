using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor.Infrastructure.Repositories
{
    public interface IRepository
    {
        /// <summary>
        /// Adds the given entity to the repository.
        /// </summary>
        /// <param name="entity">Entity to add to repository.</param>
        /// <returns>Returns entity.</returns>
        TEntity Add<TEntity>(TEntity entity) where TEntity : class;
    }
}
