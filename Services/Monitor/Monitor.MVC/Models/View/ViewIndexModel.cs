using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monitor.Domain.Entities;

namespace Monitor.MVC.Models.View
{
    public class ViewIndexModel
    {
        public ViewIndexModel(
            IEnumerable<LogInformation> logInformations,
            IEnumerable<IGrouping<string, LogInformation>> logInformationsByServices)
        {
            if (logInformations == null)
                throw new ArgumentNullException(nameof(logInformations));
            if (logInformationsByServices == null)
                throw new ArgumentNullException(nameof(logInformationsByServices));

            this.LogInformations = logInformations;
            this.LogInformationsByServices = logInformationsByServices;
        }

        public IEnumerable<LogInformation> LogInformations { get; }

        public IEnumerable<IGrouping<string, LogInformation>> LogInformationsByServices { get; }
    }
}
