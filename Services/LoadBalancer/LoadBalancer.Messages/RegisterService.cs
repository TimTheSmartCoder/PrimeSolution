using System;

namespace LoadBalancer.Messages
{
    public class RegisterService
    {
        public RegisterService(
            string scheme,
            string host,
            int port,
            string pathBase,
            string appendQuery)
        {
            if (string.IsNullOrWhiteSpace(scheme))
                throw new ArgumentNullException(nameof(scheme));
            if (string.IsNullOrWhiteSpace(host))
                throw new ArgumentNullException(nameof(host));

            this.Scheme = scheme;
            this.Host = host;
            this.Port = port;
            this.PathBase = pathBase;
            this.AppendQuery = appendQuery;
        }

        public string Scheme { get; }

        public string Host { get; }

        public int Port { get; }

        public string PathBase { get; }

        public string AppendQuery { get; }
    }
}
