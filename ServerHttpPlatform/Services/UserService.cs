using System;
using System.Collections.Generic;
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
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IUserService : IServiceCrudModel<User,int,UserEntity>
    {
        Task<User> Registration(User user);
        Task<User> Login(string login, string password, bool isHash);
        Task<User> GetUserByLogin(string login);
        Task<User> UpdateRole(int id, string role);
        Task<User> ConfirmEmail(int userId, string code);
        Task<User> GetUserByEmail(string email);
        Task<User> ChangeLogin(int userId, string login);
        Task<User> ChangePassword(int userId, string password);

        Task<List<User>> GetUserByOrganizationId(int orgId);
        Task<User> ExtendRole(int userId, string line, bool isIpn);
        Task<User> UpdateUser(int userId, User model);
        Task<User> ChangeEmail(int userId, string email);
        Task<bool> SendResetPasswordEmail(int id, string token, string name, string email);
        Task<User> ChangeOrganization(int userId, int? organizationId);
        Task<bool> ReSendEmailConfirmation(string email);
      
    }
    public class UserService:ServiceCrudModel<User, int, UserEntity>, IUserService
    {

        protected ISendEmailService SendEmailService;
        protected IOrganizationService OrganizationService;
        protected IEmailConfirmationService EmailService;
        protected IUserReadOnlyService ReadOnlyService;

        public UserService(IMapper mapper, IOrganizationService organizationService, IUserReadOnlyService readOnlyService,
                          ISendEmailService emailService, IUserRepository repository, IEmailConfirmationService emailDbService) : base(mapper, repository)
        {
            OrganizationService = organizationService;
            SendEmailService = emailService;
            EmailService = emailDbService;
            ReadOnlyService = readOnlyService;
        }


        public override async  Task<User> Get(int id)
        {
            var user = await base.Get(id);
            if (user == null) return null;
            if (user.UserOrganizationId != null)
            {
                var organization = await OrganizationService.Get((int) user.UserOrganizationId);
                user.UserOrganization = organization;
                user.UserOrganizationName = organization.Name;
            }

            return user;
        }

        public async Task<User> Registration(User user)
        {
            user.EmailConfirm = false;
            user.Role = "User";
            user.Salt = GenerateUserSalt();
            user.Password = HashUserPassword(user.Password, user.Salt);
            var created = await Create(user);
            int userId = created.Id;
            string login = created.Login;
            await SendEmailConfirm(login, userId, user);
            return created;
        }

        private async Task SendEmailConfirm(string login, int userId, User user)
        {
            var existConfirm = await EmailService.List(new EmailConfirmationByUserIdSpecification(userId));
            if (existConfirm.Count != 0)
            {
                foreach (var conf in existConfirm)
                {
                    await EmailService.Delete(conf.Id);
                }
            }
            var emailConfirm = await EmailService.CreateNewInstance(login, userId);
            var code = HttpUtility.UrlEncode(emailConfirm.Code);
            var url = "https://" + $"communication-platform.herokuapp.com/#/confirm/{userId}/{code}";
            await SendEmailService.SendConfirmLetter(user.Email, $"{user.FirstName} {user.SecondName} {user.LastName}", url);
        }

        public async Task<bool> ReSendEmailConfirmation(string email)
        {
            var user = List(new UserByEmailSpecification(email)).Result.FirstOrDefault();
            if(user==null) return false;
            if (user.EmailConfirm) return false;
            var emailConfirm = (await EmailService.List(new EmailConfirmationByUserIdSpecification(user.Id))).FirstOrDefault();
            if (emailConfirm == null) return false;
            var code = HttpUtility.UrlEncode(emailConfirm.Code);
            var url = "https://" + $"communication-platform.herokuapp.com/#/confirm/{user.Id}/{code}";
            await SendEmailService.SendConfirmLetter(user.Email, $"{user.FirstName} {user.SecondName} {user.LastName}", url);
            return true;
        }

        public async Task<User> GetUserByLogin(string login)
        {
            var user = (await Repository.ListAsync(new UserByLoginSpecification(login))).FirstOrDefault();
            var result = Mapper.Map<User>(user);
            return result;
        }

        public async Task<List<User>> GetUserByOrganizationId(int orgId)
        {
            var user = await Repository.ListAsync(new UsersByOrganizationIdSpecification(orgId, new PagedSortListQuery().TakeAll()));
            return Mapper.Map<List<User>>(user);
        }


        public async Task<User> Login(string login, string password, bool isHash)
        {
            var user = (await Repository.ListAsync(new UserByLoginSpecification(login))).FirstOrDefault();
            if (user == null) return null;
            if (isHash)
            {
                return Mapper.Map<User>(user);
            }
            string hashed = HashUserPassword(password, user.Salt);
            if (hashed != user.Password) return null;
            var result = Mapper.Map<User>(user);
            return result;

        }

        public async Task<User> ConfirmEmail(int userId, string code)
        {
            bool confirm = await EmailService.CheckCode(userId, code);
            if (!confirm) return null;
            var user = await Get(userId);
            user.EmailConfirm = true;
            var updated = await Update(user);
            return updated;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var users = await Repository.ListAsync(new UserByEmailSpecification(email));
            if (users.Count == 0) return null;
            var entity =  users.FirstOrDefault();
            return Mapper.Map<User>(entity);

        }
        public async Task<User> ChangeLogin(int userId, string login)
        {
            var log = await GetUserByLogin(login); 
            if (log != null) throw new NotSupportedException("There is such login");
            var exist = await Get(userId);
            if (exist == null) throw new KeyNotFoundException("There is no such user");
            exist.UserOrganization = null;
            exist.Login = login;
            var changed = await Update(exist);
            return changed;
        }

        public async Task<User> ChangeOrganization(int userId, int? organizationId)
        {
            var user = await Get(userId);
            if (user == null) return null;
            user.UserOrganizationId = organizationId == 0?null:organizationId;
            user.UserOrganization = null;
            var changed = await Update(user);
            return changed;
        }

        public async Task<bool> SendResetPasswordEmail(int id, string token, string name, string email)
        {
            var url = "https://" + $"communication-platform.herokuapp.com/#/reset_password/{id}/{token}";
            await SendEmailService.SendResetPasswordLetter(email, name, url);
            return true;
        }


        public async Task<User> ChangePassword(int userId, string password)
        {
            var user = await Get(userId);
            if (user == null) return null;
            user.Salt = GenerateUserSalt();
            user.Password = HashUserPassword(password, user.Salt);
            user.UserOrganization = null;
            var changed = await Update(user);
            return changed;
        }


        public async Task<User> ChangeEmail(int userId, string email)
        {
            var firstUser = await Get(userId);
            if (firstUser == null) return null;
            firstUser.Email = email;
            firstUser.EmailConfirm = false;
            firstUser.UserOrganization = null;
            var user = await Update(firstUser);
            string login = user.Login;
            var emailConfirm = await EmailService.CreateNewInstance(login, userId);
            var code = HttpUtility.UrlEncode(emailConfirm.Code);
            var url = "https://" + $"communication-platform.herokuapp.com/#/confirm/{userId}/{code}";
            await SendEmailService.SendConfirmLetter(user.Email, $"{user.FirstName} {user.SecondName} {user.LastName}", url);
            return user;
        }


        public async Task<User> UpdateUser(int userId, User model)
        {
            var user = await Get(userId);
            if (user == null) return null;
            user.UserOrganization = null;
            user.FirstName = model.FirstName;
            user.SecondName = model.SecondName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            return await Update(user);
        }


        public async Task<User> ExtendRole(int userId, string line, bool isIpn)
        {
            var user = await Get(userId);
            if (user == null) return null;
            var result = ReadOnlyService.ExistsByIpnOrPassportNumber(line, isIpn, user);
            if (!result) return user;
            user.Role += ", SuperUser";
            user.UserOrganization = null;
            var updated = await Update(user);
            return updated;
        }

        public async Task<User> UpdateRole(int id, string role)
        {
            var userModel = await Get(id);
            if (userModel == null) return null;
            userModel.Role = role;
            userModel.UserOrganization = null;
            var updated = await Update(userModel);
            return updated;
        }


        private string GenerateUserSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }
        private string HashUserPassword(string password, string stringSalt)
        {
            byte[] salt = Convert.FromBase64String(stringSalt);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
