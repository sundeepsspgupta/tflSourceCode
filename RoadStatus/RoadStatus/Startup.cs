using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TFL.Config;
using TFL.Config.Interface;
using TFL.Service;

namespace RoadStatus
{
    public static class Startup
    {
        /// <summary>
        /// Injecting class instance using dependency injection 
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false).Build();

            services.AddSingleton(configuration);
            services.AddSingleton<ITFLEndPoint, ConfigDetails>();
            services.AddSingleton<TFLService>();
            services.Configure<TFLEndPoint>(configuration.GetSection("TFLEndPoint"));

            return services;
        }
    }
}
