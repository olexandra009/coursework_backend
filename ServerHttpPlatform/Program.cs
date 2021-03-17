using System;
using System.Collections.Generic;
using Autofac.Extensions.DependencyInjection;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PlatformDbContext>();
               
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
              var port = Environment.GetEnvironmentVariable("PORT");
              return Host.CreateDefaultBuilder(args)
                    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                    .ConfigureServices(services => services.AddAutofac())
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>().UseUrls("http://*:"+port);
                    });
        }

    }
}
