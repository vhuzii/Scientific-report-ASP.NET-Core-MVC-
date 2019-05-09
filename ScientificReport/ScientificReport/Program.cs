using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ScientificReport.Data.DataAccess;
using ScientificReport.Models;

namespace ScientificReport
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ReportContext>();
                RolesInitializer.InitializeAsync(context,services).Wait();
            }
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
