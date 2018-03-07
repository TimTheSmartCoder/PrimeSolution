using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LoadBalancer.Balancer;

namespace LoadBalancer.Proxy
{
    public interface IProxy
    {
        HttpClient Client { get; }

        ILoadBalancer LoadBalancer { get; }
    }
}
