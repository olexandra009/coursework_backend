using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.Specification;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.PersonalInfoDataBase;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
                MultimediaEntity me = new MultimediaEntity {Url = "kfkfkf", ApplicationId = 1};
                UserRepository us = new UserRepository(context);
                UserEntity user = us.GetByIdAsync(1).Result;
                List<MultimediaEntity> ml = new List<MultimediaEntity>();
                ml.Add(me);
                ApplicationEntity ap = new ApplicationEntity()
                {
                    Author = user, Text = "hiii", Multimedias = ml, AuthorId = 1, Status = Status.Waiting,
                    Subject = "kfkf", Result = ""
                };
                ApplicationRepository r = new ApplicationRepository(context);
                var a = r.AddAsync(ap).Result;

            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices(services => services.AddAutofac())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
