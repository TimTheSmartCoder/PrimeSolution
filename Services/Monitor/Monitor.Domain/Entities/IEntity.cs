using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor.Domain.Entities
{
    public interface IEntity<TEntityId>
    {
        /// <summary>
        /// Id of the entity.
        /// </summary>
        TEntityId Id { get; }
    }
}
