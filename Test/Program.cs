using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type in host: ");

            var host = Console.ReadLine();

            Console.WriteLine("Please type in how long requests should be sent(seconds): ");

            var time = int.Parse(Console.ReadLine());

            var end = DateTime.Now.AddSeconds(time);

            var destination = new Uri(host);
            
            HttpClient client = new HttpClient();

            HttpRequestMessage requestMessage = new HttpRequestMessage(
                HttpMethod.Get, 
                destination);

            List<Task> requests = new List<Task>();

            while (DateTime.Now < end)
            {
                var task = client.SendAsync(requestMessage);

                task.ContinueWith((message) =>
                {
                    var response = message.Result;

                    Console.WriteLine("Recevied response from service: " + response.StatusCode);
                });

                requests.Add(task);

                Thread.Sleep(1000);

                Console.WriteLine("Sent http request to service.");
            }

            foreach (var request in requests)
            {
                request.Wait();
            }

            Console.WriteLine("All requests is end, press any key to exit.");
            Console.ReadLine();
        }
    }
}
