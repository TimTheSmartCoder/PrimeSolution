﻿using System;
using Microsoft.AspNetCore.Http;

namespace LoadBalancer.Balancer
{
    /// <summary>
    /// Service Options.
    /// </summary>
    public class ServiceOptions
        : IServiceOptions
    {
        public ServiceOptions(
            string scheme, 
            HostString host, 
            PathString pathBase, 
            QueryString appendQuery,
            string serviceId)
        {
            if (string.IsNullOrWhiteSpace(scheme))
                throw new ArgumentNullException(nameof(scheme));
            if (host == null)
                throw new ArgumentNullException(nameof(host));
            if (string.IsNullOrWhiteSpace(serviceId))
                throw new ArgumentNullException(nameof(serviceId));

            this.Scheme = scheme;
            this.Host = host;
            this.PathBase = pathBase;
            this.AppendQuery = appendQuery;
            this.ServiceId = serviceId;
        }

        public string Scheme { get;}

        public HostString Host { get; }

        public PathString PathBase { get; }

        public QueryString AppendQuery { get; }

        public string ServiceId { get; }
    }
}
