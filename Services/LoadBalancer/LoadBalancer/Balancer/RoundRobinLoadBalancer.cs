using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadBalancer.Balancer
{
    public class RoundRobinLoadBalancer
        : ILoadBalancer
    {
        /// <summary>
        /// List containing all the services, available for the
        /// load balancer.
        /// </summary>
        private readonly IList<IServiceOptions> services;

        /// <summary>
        /// Cursor which points to the last given services.
        /// </summary>
        private int cursor;

        /// <summary>
        /// Default cursor value.
        /// </summary>
        private const int CursorDefault = -1;

        public RoundRobinLoadBalancer()
        {
            this.services = new List<IServiceOptions>();
            this.cursor = CursorDefault;
        }

        public void Add(IServiceOptions serviceOptions)
        {
            if (serviceOptions == null)
                throw new ArgumentNullException(nameof(serviceOptions));

            this.services.Add(serviceOptions);
        }

        public IServiceOptions Next()
        {
            // Check if any services is available.
            if (!this.services.Any())
                return null;

            // Check if the cursor points to the last service
            // if it points to the last service, we start from
            // the begninign again.
            this.cursor++;

            if (this.cursor >= this.services.Count)
                this.cursor = 0;

            return this.services[this.cursor];
        }
    }
}
