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
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.VotesSpecification;
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
                //NewsRepository news = new NewsRepository(context);
               // UserRepository use = new UserRepository(context);
               // UserEntity user = use.GetByIdAsync(1).Result;
               
                PetitionRepository pet = new PetitionRepository(context);
                VotesRepository uss = new VotesRepository(context);
                var usl = uss.ListAsync(new VotesForPetitionWithIdSpecification(1)).Result;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(usl.Count);
                Console.WriteLine(usl[0].UserId);
                Console.WriteLine("----------------------------------------");
               
                usl = uss.ListAsync(new VotesForPetitionWithIdSpecification(100)).Result;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(usl.Count);
                // Console.WriteLine(usl[0].Login);
                Console.WriteLine("----------------------------------------");

                //PetitionEntity p = new PetitionEntity();
                //p.Text = "New test close successful petition";
                //p.StarDate = new DateTime(2000, 12, 1);
                //p.FinishDate = new DateTime(2021, 1, 10);
                //p.Header = "Header";
                //p.Author = user;
                //p.AuthorId = user.Id;

                //var pp = pet.AddAsync(p).Result;

                //List<PetitionEntity> pett = pet.ListAsync(new FilterStatusPetitionSpecification("close", "unsucc")).Result;
                //Console.WriteLine("----------------------------------------");
                //Console.WriteLine(pett.Count);
                //Console.WriteLine("----------------------------------------");

                //pett = pet.ListAsync(new FilterStatusPetitionSpecification("active", "unsucc")).Result;
                //Console.WriteLine("----------------------------------------");
                //Console.WriteLine(pett.Count);
                //Console.WriteLine("----------------------------------------");

                //pett = pet.ListAsync(new FilterStatusPetitionSpecification(null,"unsucc")).Result;
                //Console.WriteLine("----------------------------------------");
                //Console.WriteLine(pett.Count);
                //Console.WriteLine("----------------------------------------");

                //pett = pet.ListAsync(new FilterStatusPetitionSpecification(null, "succ")).Result;
                //Console.WriteLine("----------------------------------------");
                //Console.WriteLine(pett.Count);
                //Console.WriteLine("----------------------------------------");

                //pett = pet.ListAsync(new FilterStatusPetitionSpecification("active")).Result;
                //Console.WriteLine("----------------------------------------");
                //Console.WriteLine(pett.Count);
                //Console.WriteLine("----------------------------------------");
                //List<NewsEntity> a =  news.ListAsync().Result;
                //   var pc = services.GetRequiredService<PersonalUsersInfoContext>();
                // pc.Users.Count();

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
