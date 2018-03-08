using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using Monitor.Messages;

namespace Monitor.AspNetCore.Middleware
{
    public class LogInformationMiddleware 
    {
        private readonly RequestDelegate next;
        private readonly IBus bus;

        public LogInformationMiddleware(RequestDelegate next, IBus bus)
        {
            if(next == null)
                throw  new ArgumentNullException(nameof(next));
            if(bus == null)
                throw new ArgumentNullException(nameof(bus));

            this.next = next;
            this.bus = bus;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            await this.next(context);
            stopwatch.Stop();

            long duration = stopwatch.ElapsedMilliseconds;

            LogInformation logMessage = new LogInformation(
                DateTime.Now, 
                context.Response.StatusCode, 
                duration, 
                context.Request.Method, 
                context.Request.Path);

            bus.Publish(logMessage);
        }


    }
}
