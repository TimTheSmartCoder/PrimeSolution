using System;
using Microsoft.AspNetCore.Builder;

namespace LoadBalancer.Proxy
{
    public static class ProxyApplicationBuilderExtension
    {
        public static void UseProxy(this IApplicationBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.UseMiddleware<ProxyMiddleware>();
        }
    }
}
