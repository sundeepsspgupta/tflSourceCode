using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TFL.Domain;
using TFL.Service;

namespace RoadStatus
{
    class Program
    {   
        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Length >2)
            {
                Console.WriteLine("Enter Road code or only one Road Code");
                Environment.ExitCode = 1;
                return;
            }
            string roadCode = args[0];

            // Injecting class instance using Dependency injection via IServiceCollection. 
            var services = Startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            Run(serviceProvider, roadCode).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Call Api 
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="roadCode"></param>
        /// <returns></returns>
        static async Task Run(ServiceProvider serviceProvider, string roadCode)
        {
            TFLResponse tFLResponse = await serviceProvider.GetService<TFLService>().InvokeTFLApi(roadCode);
            Console.WriteLine(tFLResponse.ResponseMessage);
            Environment.ExitCode = tFLResponse.ResponseCode;
        }
    }
}
