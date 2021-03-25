using System;
using System.Security.Cryptography;
using Autofac.Extensions.DependencyInjection;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MimeKit;


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
                //context.Users.Add(UserCreating("Admin", "Admin", "Admin", "as2ekcm", "admin@admin.ad", "qwRnvod23_ric", "User, SuperUser, NewsAndEvents, Moderator, ApplicationAdmin, UserManager", "", 6));
                //context.Users.Add(UserCreating("Градислав", "Левович", "Маковецький", "grl@co.ua", "t_log011", "1W3e5p78", "User, SuperUser", "", 3));
                //context.Users.Add(UserCreating("Радечко", "Владиславович", "Миклуха", "test@adb.b", "t_log012", "1Z3e5p79", "User, SuperUser", "", 2));
                //context.Users.Add(UserCreating("Щек", "Юліанович", "Гординський", "qwerty@q", "t_log013", "1Q3e5p80", "User, SuperUser", "", 3));
                //context.Users.Add(UserCreating("Хотян", "Омелянович", "Матерський", "a@a", "t_log014", "1S3e5p81", "User, SuperUser", "", null));
                //context.Users.Add(UserCreating("Маврикій", "Драганович", "Міцкевич", "b@b", "t_log015", "1A3e5p82", "User, SuperUser, UserManager", "", 4));
                //context.Users.Add(UserCreating("Русява", "Мстиславівна", "Криклій", "c@c", "t_log016", "1Y3e5p83", "User", "", null));
                //context.Users.Add(UserCreating("Руслана", "Мстиславівна", "Криклій", "c@c1", "t_log0162", "1Y3e5p83", "User", "", null));
                //context.Users.Add(UserCreating("Фаїна", "Милославівна", "Наливайко", "d@dde", "t_log017", "1R3e5p84", "User, SuperUser", "", null));
                //context.Users.Add(UserCreating("Жозефіна", "", "Заєць", "jozefina@joz", "t_log018", "1SZ3e5p85", "User, SuperUser, NewsAndEvents", "", 2));
                //context.Users.Add(UserCreating("Юдихва", "Омелянівна", "Томків", "a@w", "t_log019", "1pP3e5p86", "User, SuperUser", "", null));
                //context.Users.Add(UserCreating("Щедриця", "Левівна", "Довженко", "a@v", "t_log020", "1Y3e5p87", "User, SuperUser, NewsAndEvents", "", 7));
                //context.Users.Add(UserCreating("Юхим", "", "Федорович", "Поточняк", "r@wc", "t_log022", "rtPTmmwl2", "User, SuperUser, ApplicationAdmin", null));
                //context.Users.Add(UserCreating("Соломія", "Азарівна", "Сторож", "as@we", "t_log021", "1i3e5p88", "User, SuperUser", "", 5));
                //context.Users.Add(UserCreating("Moderator", "Admin", "Admin", "moderator@admin", "ajsp_29", "nsqEnnc_90", "User, SuperUser, Moderator", "", 6))

                context.Newses.Add(CreateNews(36, new DateTime(2021, 3, 17, 12, 30, 12), true, false, "У роботі пошуковика Google виникли збої", "txt"));
                context.Newses.Add(CreateNews(42, new DateTime(2021, 3, 20, 16, 30, 12), true, false, "Землю накриє тривала магнітна буря: спеціалісти назвали терміни", "txt"));
                context.Newses.Add(CreateNews(42, new DateTime(2021, 3, 25, 13, 30, 12), true, false, "На станцію \"Академік Вернадський\" вирушила 26-та антарктична експедиція", "txt"));
                context.Newses.Add(CreateNews(36, new DateTime(2021, 3, 25, 14, 30, 12), true, false, "Через зміни клімату літо може збільшитися вдвічі - вчені", "txt"));


                context.SaveChanges();
            }
            host.Run();
        }

        private static EventEntity CreateEvent(int author, DateTime start, DateTime end, bool edited, bool showAuthor, bool notification, string name, string description)
        {
            return new EventEntity()
            {
                AuthorId = author,
                Description = description,
                Edited = edited,
                EmailNotification = notification,
                EndDate = end,
                StartDate = start,
                Name = name,
                ShowAuthor = showAuthor, 

            };
        }

        private static NewsEntity CreateNews(int author, DateTime date, bool showAuth, bool edited, string header, string text)
        {
            NewsEntity news = new NewsEntity()
            {
                AuthorId = 1,
                DateTimeCreation = date,
                Edited = edited,
                Header = header,
                Text = text,
                ShowAuthor = showAuth
            };
            return news;
        }
        //private static UserEntity UserCreating(string firstName, string secondName, string lastName, string email, string login, 
        //        string password, string roles, string phone, int? organizationId)
        //{
        //    byte[] salt = new byte[128 / 8];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(salt);
        //    }
        //    string saltStr =  Convert.ToBase64String(salt);
        //    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //        password: password,
        //        salt: salt,
        //        prf: KeyDerivationPrf.HMACSHA1,
        //        iterationCount: 10000,
        //        numBytesRequested: 256 / 8));

        //    UserEntity entity = new UserEntity()
        //    {
        //        FirstName = firstName,
        //        SecondName = secondName,
        //        LastName = lastName,
        //        Login = login,
        //        Email = email,
        //        EmailConfirm = true,
        //        Role = roles, 
        //        PhoneNumber = phone,
        //        Password = hashed,
        //        Salt = saltStr,
        //        UserOrganizationId = organizationId
        //    };
        //    return entity;
        //}

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
