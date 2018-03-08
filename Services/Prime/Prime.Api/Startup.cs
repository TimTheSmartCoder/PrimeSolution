using System;
using EasyNetQ;
using LoadBalancer.Messages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monitor.AspNetCore;

namespace Prime.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Get the scheme, host, port of the server currently running.
            this.EnviromentUri = new Uri(configuration["urls"]);

            try
            {
                // Instancetiate EasyNetQ for later.
                //this.Bus = RabbitHutch.CreateBus($"host={configuration["EasyNetQ:Host"]};persistentMessages={configuration["EasyNetQ:PersistentMessages"]}");
                this.Bus = RabbitHutch.CreateBus("host=localhost");

                this.Bus.Publish<LoadBalancer.Messages.RegisterService>(new RegisterService(
                    this.EnviromentUri.Scheme,
                    this.EnviromentUri.Host,
                    this.EnviromentUri.Port,
                    this.EnviromentUri.AbsolutePath,
                    this.EnviromentUri.Query));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IBus Bus { get; }

        public IConfiguration Configuration { get; }

        public Uri EnviromentUri { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
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

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseLogInformation();

            app.UseMvc();

            // Register the service itself with the load balancer, using
            // rabbitmq as a message service. First do now because the
            // app have first initialized Mvc here.
        }
    }
}
