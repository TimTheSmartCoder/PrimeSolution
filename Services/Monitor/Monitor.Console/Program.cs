using System;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.EntityFrameworkCore;
using Monitor.Infrastructure.Configurations.EFCore;
using Monitor.Infrastructure.Repositories;
using Monitor.Infrastructure.Repositories.EFCore;
using Monitor.Messages;

namespace Monitor.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            using (IBus bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.SubscribeAsync<LogInformation>("monitor", OnLogInformation);
                System.Console.WriteLine("Press any key to exit");
                System.Console.ReadLine();
            }          
        }

        private static async Task OnLogInformation(LogInformation message)
        {
            using (MonitorDbContext context = new MonitorContextFactory().CreateDbContext(new string[]{}))
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);

                Monitor.Domain.Entities.LogInformation log = 
                    new Domain.Entities.LogInformation(
                        message.Timestamp,
                        message.HttpStatus, 
                        message.Duration, 
                        message.HttpMethod, 
                        message.Path,
                        message.ServiceId);

                unitOfWork.Repository.Add(log);

                await unitOfWork.SaveChanges();
            }

            System.Console.WriteLine("--");
            System.Console.WriteLine($"Timestamp: {message.Timestamp}");
            System.Console.WriteLine($"Duration: {message.Duration} millisec");
            System.Console.WriteLine($"HttpStatus: {message.HttpStatus}");
            System.Console.WriteLine($"Path: {message.Path}");
            System.Console.WriteLine($"Httpmethod: {message.HttpMethod}");
            System.Console.WriteLine($"SeriveId: {message.ServiceId}");
            System.Console.WriteLine("--");
        }
    }
}
