using System;
using System.IO;
using System.Reflection;
using Autofac;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework;
using KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.PersonalInfoDataBase;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Auth;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.AutofacModules;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Authentification
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false; //SSL no need 
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                       ValidateIssuer = true,                                       // укзывает, будет ли валидироваться издатель при валидации токена
                       ValidIssuer = AuthOptions.ISSUER,                            // строка, представляющая издателя
                       ValidateAudience = true,                                     // будет ли валидироваться потребитель токена
                       ValidAudience = AuthOptions.AUDIENCE,                        // установка потребителя токена
                       ValidateLifetime = true,                                     // будет ли валидироваться время существования
                       IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),    // установка ключа безопасности
                       ValidateIssuerSigningKey = true                              // валидация ключа безопасности
                    };
                });
            #endregion

            services.AddDbContext<PlatformDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 11))));

            services.AddDbContext<PersonalUsersInfoContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("ReadOnlyConnection"),
                    new MySqlServerVersion(new Version(8, 0, 11))));

            services.AddAutoMapper((configuration) => configuration.AddProfile<MappingProfile>(),
                typeof(Startup)); // scan and register automapper profiles in this assembly

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ServerHttpPlatform", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }


        

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac here. Don't
            // call builder.Populate(), that happens in AutofacServiceProviderFactory
            // for you.
            builder.RegisterModule(new RepositoryUtcAutofacModule());
            builder.RegisterModule(new RepositoryReadOnlyAutofacModule());
            builder.RegisterModule(new ServicesAutofacModule());

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServerHttpPlatform v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
