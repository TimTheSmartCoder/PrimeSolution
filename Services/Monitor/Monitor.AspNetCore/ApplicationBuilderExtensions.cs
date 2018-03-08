using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Monitor.AspNetCore.Middleware;
using Monitor.Messages;

namespace Monitor.AspNetCore
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseLogInformation(this IApplicationBuilder builder)
        {
            if(builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.UseMiddleware<LogInformationMiddleware>();
        }
    }
}
