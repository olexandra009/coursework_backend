using System;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IEmailConfirmationService : IServiceCrudModel<EmailConfirmation, int, EmailConfirmEntity >
    {
        public Task<EmailConfirmation> CreateNewInstance(string login, int id);
        public Task<bool> CheckCode(int id, string code);
    }
    public class EmailConfirmationService : ServiceCrudModel<EmailConfirmation, int, EmailConfirmEntity>, IEmailConfirmationService
    {

        public EmailConfirmationService(IMapper mapper, IEmailConfirmationRepository repository) : base(mapper, repository)
        {
        }

        public Task<EmailConfirmation> CreateNewInstance(string login, int id)
        {
            var code = GetCodeForEmailConfirmation(login, id);
            var ec = new EmailConfirmation()
            {
                Code = code,
                UserId = id
            };
            Console.BackgroundColor = System.ConsoleColor.DarkCyan;
            Console.WriteLine($"Here we are: {id}, {code}");
            Console.WriteLine($"Here we are: {ec.Id}, {ec.UserId}");
            var entity = Mapper.Map<EmailConfirmEntity>(ec);
            Console.WriteLine($"Here we are: {entity.Id}, {entity.UserKey}");
            return base.Create(new EmailConfirmation()
            {
                Code = code, UserId = id
            });

        }

        public async Task<bool> CheckCode(int id, string code)
        {
            var emailModel = await Get(id);
            return emailModel != null && emailModel.Code.ToLower().Equals(code.ToLower());
        }

        private string GetCodeForEmailConfirmation(string login, int id)
        {
            var dateString = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            var guid = new Guid();
            var stringToCode = $"{id}-{login}-{dateString}-{guid}";
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            var code = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: stringToCode,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return code;
        }
    }
}
