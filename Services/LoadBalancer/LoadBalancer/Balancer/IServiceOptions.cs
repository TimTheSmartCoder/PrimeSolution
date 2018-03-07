using Microsoft.AspNetCore.Http;

namespace LoadBalancer.Balancer
{
    public interface IServiceOptions
    {
        /// <summary>
        /// Destination uri scheme
        /// </summary>
        string Scheme { get; }

        /// <summary>
        /// Destination uri host
        /// </summary>
        HostString Host { get; }

        /// <summary>
        /// Destination uri path base to which current Path will be appended
        /// </summary>
        PathString PathBase { get; }

        /// <summary>
        /// Query string parameters to append to each request
        /// </summary>
        QueryString AppendQuery { get; }
    }
}
