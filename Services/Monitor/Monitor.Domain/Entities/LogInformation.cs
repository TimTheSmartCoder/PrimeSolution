using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor.Domain.Entities
{
    public class LogInformation : IEntity<int>
    {
        public LogInformation(
            DateTime timestamp,
            int httpStatus,
            long duration,
            string httpMethod,
            string path,
            string serviceId)
        {
            if (string.IsNullOrWhiteSpace(httpMethod))
                throw new ArgumentNullException(nameof(httpMethod));
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(serviceId))
                throw new ArgumentNullException(nameof(serviceId));

            this.Timestamp = timestamp;
            this.HttpStatus = httpStatus;
            this.Duration = duration;
            this.HttpMethod = httpMethod;
            this.Path = path;
            this.ServiceId = serviceId;
        }

        public LogInformation() { }

        public int Id { get; private set; }
        public DateTime Timestamp { get; private set; }
        public int HttpStatus { get; private set; }
        public long Duration { get; private set; }
        public string HttpMethod { get; private set; }
        public string Path { get; private set; }
        public string ServiceId { get; private set; }
    }
}
