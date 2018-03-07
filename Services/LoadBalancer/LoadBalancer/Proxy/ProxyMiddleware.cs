using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;

namespace LoadBalancer.Proxy
{
    public class ProxyMiddleware
    {
        private readonly RequestDelegate next;

        public ProxyMiddleware(RequestDelegate next)
        {
            if (next == null)
                throw new ArgumentException(nameof(next));

            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return ProxyRequest(context);
        }

        public static async Task ProxyRequest(HttpContext context)
        {
            // Get the load balancer.
            var loadBalancer = context.RequestServices
                .GetRequiredService<IProxy>().LoadBalancer;
            
            // Get the service information, so we can send the
            // request the an service.
            var service = loadBalancer.Next();

            if (service == null)
            {
                context.Response.StatusCode = 404;
                return;
            }

            var destination = new Uri(UriHelper.BuildAbsolute(
                service.Scheme,
                service.Host,
                service.PathBase, 
                context.Request.Path, 
                context.Request.QueryString.Add(service.AppendQuery)
                ));

            // Create the HttpRequestMessage to send to the service we are
            // proxing.
            using (var requestMessage = ProxyUtils
                .CreateProxyHttpRequest(context, destination))
            {
                var client = context.RequestServices
                    .GetRequiredService<IProxy>().Client;

                using (var responseMessage = await ProxyUtils
                    .SendProxyHttpRequest(context, requestMessage, client))
                {
                    // Copy the response from the service to HttpContext
                    // Response to serve the user.
                    await ProxyUtils.CopyProxyHttpResponse(context, responseMessage);
                }
            }
        }
    }
}
