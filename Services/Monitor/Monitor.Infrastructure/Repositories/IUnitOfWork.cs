using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Repository to use to save data and so on.
        /// </summary>
        IRepository Repository { get; }

        /// <summary>
        /// Saves all the changes which have been applied to this
        /// unit of work.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> SaveChanges(CancellationToken cancellationToken = default(CancellationToken));
    }
}
