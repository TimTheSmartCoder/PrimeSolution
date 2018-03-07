using System;
using System.Net.Http;
using LoadBalancer.Balancer;

namespace LoadBalancer.Proxy
{
    public class Proxy
        : IProxy
    {
        public Proxy(ILoadBalancer loadBalancer)
        {
            if (loadBalancer == null)
                throw new ArgumentNullException(nameof(loadBalancer));

            this.Client = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = false, UseCookies = false
            });

            this.LoadBalancer = loadBalancer;
        }

        public HttpClient Client { get; }

        public ILoadBalancer LoadBalancer { get; }
    }
}
