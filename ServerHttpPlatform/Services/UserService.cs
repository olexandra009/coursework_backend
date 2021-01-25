using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Ardalis.Specification;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    //todo implement methods 
    public interface IUserService : IServiceCrudModel<User,int,UserEntity>
    {
        Task<User> Registration(User user);
        Task<User> Login(string login, string password);
        Task<User> UpdateRole(int id, string role);
    }
    public class UserService:ServiceCrudModel<User, int, UserEntity>, IUserService
    {

       // protected ISendEmailService SendEmailService;
        protected IOrganizationService OrganizationService;
        protected IEmailConfirmationService EmailService;
    
        public UserService(IMapper mapper, IOrganizationService organizationService, 
                         /*  ISendEmailService emailService,*/ IUserRepository repository, IEmailConfirmationService emailDbService) : base(mapper, repository)
        {
            OrganizationService = organizationService;
           // SendEmailService = emailService;
            EmailService = emailDbService;
        }

        ////override to add organization
        //public override async Task<List<User>> List(ISpecification<UserEntity> specification)
        //{
        //    List<UserEntity> entities = await Repository.ListAsync(specification);
        //    List<User> models = Mapper.Map<List<User>>(entities);
        //    foreach (var user in models)
        //    {
        //        if(user.UserOrganizationId==null) continue;
        //        user.UserOrganization = await OrganizationService.Get((int)user.UserOrganizationId);

        //    }
        //    return models;
        //}

       

        public async Task<User> Registration(User user)
        {
            user.EmailConfirm = false;
            user.Role = "User";
            //await SendEmailService.SendConfirmLetter(user.Email);
            var created = await Create(user);
            var code = GetCodeForEmailConfirmation(created.Login, created.Id);
            var current = await EmailService.Create(new EmailConfirmation()
            {
                Code = code, Id = created.Id

            });

            return created;
        }

        public async Task<User> Login(string login, string password)
        {
            var user = Repository.ListAsync(new UserByLoginSpecification(login, password)).Result.FirstOrDefault();
            var result = Mapper.Map<User>(user);
            return result;

        }

        public async Task<User> UpdateRole(int id, string role)
        {
            var user = await Repository.GetByIdAsync(id);
            var userModel = Mapper.Map<User>(user);
            userModel.Role = role;
            var userEntity = Mapper.Map<UserEntity>(userModel);
            await Repository.UpdateAsync(userEntity);
            User result = Mapper.Map<User>(userEntity);
            result = await Task.FromResult(result).ConfigureAwait(false);
            return result;
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
