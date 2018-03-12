using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
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

        /// <summary>
        /// Get querable which points to entities where the criteria is true.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IQueryable<TEntity> Where<TEntity>(Expression<Func<TEntity, bool>> criteria) 
            where TEntity : class;
        
    }
}
