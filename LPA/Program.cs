using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LPA.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LPA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            //1. Get the IWebHost which will host this application.
            var host = CreateWebHostBuilder(args).Build();
            // 2.Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                //3. Get the instance of ProductosDBContext in our services layer
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ProductosDbContext>();

                //4. Call the DataGenerator to create sample data
                GeneradorDeDatos.GenerarDatos(services);
            }
            //Continue to run the application
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
