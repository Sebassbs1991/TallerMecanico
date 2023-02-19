using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMecanico.API.Datos;

namespace TallerMecanico.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();
            Cargando (host);
            host.Run();
        }

        private static void Cargando (IWebHost host)
        {
            IServiceScopeFactory scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                CargarInfo seeder = scope.ServiceProvider.GetService<CargarInfo>();
                seeder.CargarDatosAsync().Wait();

            }
        }

               
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            
                {
                    return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();   
                }
    }
}
