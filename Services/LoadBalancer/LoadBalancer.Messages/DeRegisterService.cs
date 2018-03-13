using System;
using System.Collections.Generic;
using System.Text;

namespace LoadBalancer.Messages
{
    public class DeRegisterService
    {
        public DeRegisterService(string serviceId)
        {
            if (string.IsNullOrWhiteSpace(serviceId))
                throw new ArgumentNullException(nameof(serviceId));

            this.ServiceId = serviceId;
        }
        
        public string ServiceId { get; }
    }
}
