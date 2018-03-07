using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using LoadBalancer.Balancer;
using LoadBalancer.Proxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LoadBalancer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            this.LoadBalancer = new RoundRobinLoadBalancer();

            this.Bus = RabbitHutch.CreateBus("host=localhost");
        }

        public RoundRobinLoadBalancer LoadBalancer { get; }

        public IBus Bus { get; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            // Add the proxy service to dependency injection.
            services.AddProxy(this.LoadBalancer);

            // Add EasyNetQ for using RabbitMq.
            services.AddSingleton<IBus>(this.Bus);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IApplicationLifetime applicationLifetime,
            IHostingEnvironment env)
        {
            // Dispose EasyNetQ IBus.
            applicationLifetime.ApplicationStopping.Register(() => { this.Bus?.Dispose(); });
            
            // Subscribe to the RabbitMqServer for listening after register service
            // message, so that service can register to be available.
            Subscribe(this.Bus, this.LoadBalancer);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add the ProxyMiddleware to the application, so proxy can redirect all
            // request to the correct services with the help of the load balancer.
            app.UseProxy();

            //app.UseMvc();
        }

        private static void Subscribe(IBus bus, RoundRobinLoadBalancer loadBalancer)
        {
            bus.SubscribeAsync<LoadBalancer.Messages.RegisterService>("LoadBalancer", (message) => Task.Factory.StartNew(() =>
            {
                loadBalancer.Add(new ServiceOptions(
                    message.Scheme,
                    new HostString(message.Host, message.Port),
                    new PathString(message.PathBase), 
                    new QueryString(message.AppendQuery)));
            }));
        }
    }
}
