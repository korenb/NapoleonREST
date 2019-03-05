using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NapoleonNotes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(cfgBuilder =>
                {
                    cfgBuilder.SetBasePath(Directory.GetCurrentDirectory());
                    cfgBuilder.AddJsonFile("appsettings.json", true);
                })
                .ConfigureLogging((hostContext, cfg) =>
                {
                    cfg.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                    cfg.ClearProviders();
                    cfg.AddConsole();
                })
                .UseStartup<Startup>();
    }
}
