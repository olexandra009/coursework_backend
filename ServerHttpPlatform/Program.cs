using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
                NewsRepository news = new NewsRepository(context);
                news.GetAllItem();
                //User u = new User(1, "f", "f", "f", "29393","eiieie", "jfjf","fkfkf",
                //    null, null, new Rights(1, true,true,true, true, true, true,true,true, this), new List<News>())
                //news.CreateItem(new News(1, "jfh", "fjfjfjf", DateTime.Now, 
                //    true, false, u, 1, new List<Multimedia>() ));
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
