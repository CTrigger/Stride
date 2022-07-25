using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using NLog.Web;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;
using Repository.Context.Seed;

namespace ExampleAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
#if DEBUG
            SeedDataBase(host);
#endif
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SeedDataBase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var productContext = services.GetRequiredService<ProductContext>();
            DataSeed.ProductSeed(productContext);

            var userContext = services.GetRequiredService<UserContext>();
            DataSeed.UserSeed(userContext);
        }
    }
}
