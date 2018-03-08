using System;

namespace Monitor.Messages
{
    public class LogInformation
    {
        public LogInformation(
            DateTime timestamp, 
            int httpStatus, 
            long duration, 
            string httpMethod, 
            string path,
            string serviceId)
        {
            if(string.IsNullOrWhiteSpace(httpMethod))
                throw new ArgumentNullException(nameof(httpMethod));
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            this.Timestamp = timestamp;
            this.HttpStatus = httpStatus;
            this.Duration = duration;
            this.HttpMethod = httpMethod;
            this.Path = path;
            this.ServiceId = serviceId;
        }

        public DateTime Timestamp { get; }
        public int HttpStatus { get; }
        public long Duration { get; }
        public string HttpMethod { get; }
        public string Path { get; }
        public string ServiceId { get; }
    }
}
