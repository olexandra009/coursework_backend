﻿using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
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
            return base.Create(new EmailConfirmation()
            {
                Code = code, UserId = id
            });

        }

        public async Task<bool> CheckCode(int userId, string code)
        {
            Console.WriteLine("Check code: "+code);
            var emailModel = (await List(new CodeUserConfirmEmailSpecification(userId))).FirstOrDefault();
            if (emailModel != null)
            {
                Console.WriteLine("With: " + emailModel.Code);
            }

            if (emailModel != null && emailModel.Code.ToLower().Equals(code.ToLower()))
            {
                await Delete(emailModel.Id);
                return true;
            }

            return false;

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
