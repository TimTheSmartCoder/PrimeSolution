using System;
using LoadBalancer.Balancer;
using Microsoft.Extensions.DependencyInjection;

namespace LoadBalancer.Proxy
{
    public static class ProxyServiceCollection
    {
        public static IServiceCollection AddProxy(
            this IServiceCollection serviceCollection, 
            ILoadBalancer loadBalancer)
        {
            if (serviceCollection == null)
                throw new ArgumentNullException(nameof(serviceCollection));

            return serviceCollection.AddSingleton<IProxy>(new Proxy(loadBalancer));
        }
    }
}
