using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IUserService : IServiceCrudModel<User,int,UserEntity>
    {
        Task<User> Registration(User user);
        Task<User> Login(string login, string password);
        Task<User> GetUserByLogin(string login);
        Task<User> UpdateRole(int id, string role);
        Task<User> ConfirmEmail(int userId, string code);
        Task<User> GetUserByEmail(string email);
        Task<User> ChangeLogin(int userId, string login);
        Task<User> ChangePassword(int userId, string password);

        Task<List<User>> GetUserByOrganizationId(int orgId);
        Task<User> ExtendRole(int userId, string inp);
        Task<User> UpdateUser(int userId, User model);
        Task<User> ChangeEmail(int userId, string email);
        Task<bool> SendResetPasswordEmail(int id, string token, string name, string email);
        Task<User> ChangeOrganization(int userId, int? organizationId);
        Task<bool> ReSendEmailConfirmation(string email);
        Task SendEmailConfirm(string login, int userId, User user);
    }
    public class UserService:ServiceCrudModel<User, int, UserEntity>, IUserService
    {

        protected ISendEmailService SendEmailService;
        protected IOrganizationService OrganizationService;
        protected IEmailConfirmationService EmailService;
    

        public UserService(IMapper mapper, IOrganizationService organizationService, 
                          ISendEmailService emailService, IUserRepository repository, IEmailConfirmationService emailDbService) : base(mapper, repository)
        {
            OrganizationService = organizationService;
            SendEmailService = emailService;
            EmailService = emailDbService;
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

            //user.Password = "hidden";
            return user;
        }

        public async Task<User> Registration(User user)
        {
            user.EmailConfirm = false;
            user.Role = "User";
            var created = await Create(user);
            int userId = created.Id;
            string login = created.Login;
            await SendEmailConfirm(login, userId, user);
            return created;
        }

        public async Task SendEmailConfirm(string login, int userId, User user)
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
            var url = "https://" + $"localhost:44336/confirm_email?id={userId}&code={code}";
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
            var url = "https://" + $"localhost:44336/confirm_email?id={user.Id}&code={code}";
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


        public async Task<User> Login(string login, string password)
        {
            var user = (await Repository.ListAsync(new UserByLoginSpecification(login, password))).FirstOrDefault();
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
            var check = await GetUserByLogin(login);
            var user = await Get(userId);
            if (user == null) return null;
            if (check != null) return user; 
            user.Login = login;
            var changed = await Update(user);
            return changed;
        }

        public async Task<User> ChangeOrganization(int userId, int? organizationId)
        {
            var user = await Get(userId);
            if (user == null) return null;
            user.UserOrganizationId = organizationId;
            var changed = await Update(user);
            return changed;
        }

        public async Task<bool> SendResetPasswordEmail(int id, string token, string name, string email)
        {
            var url = "https://" + $"localhost:44336/reset_password/{id}/{token}";
            await SendEmailService.SendResetPasswordLetter(email, name, url);
            return true;
        }


        public async Task<User> ChangePassword(int userId, string password)
        {
            var user = await Get(userId);
            if (user == null) return null;
            Console.WriteLine(user.UserOrganizationId + " " + user.Id);
            user.Password = password;
            var changed = await Update(user);
            return changed;
        }


        public async Task<User> ChangeEmail(int userId, string email)
        {
            var firstUser = await Get(userId);
            firstUser.Email = email;
            firstUser.EmailConfirm = false;
            var user = await Update(firstUser);
            string login = user.Login;
            var emailConfirm = await EmailService.CreateNewInstance(login, userId);
            var code = HttpUtility.UrlEncode(emailConfirm.Code);
            var url = "https://" + $"localhost:44336/confirm_email?id={userId}&code={code}";
            await SendEmailService.SendConfirmLetter(user.Email, $"{user.FirstName} {user.SecondName} {user.LastName}", url);
            return user;
        }


        public async Task<User> UpdateUser(int userId, User model)
        {
            var user = await Get(userId);
            if (user == null) return null;
            model.Password = user.Password;
            model.Email = user.Email;
            model.EmailConfirm = user.EmailConfirm;
            model.Id = user.Id;
            model.UserOrganizationId = user.UserOrganizationId;
            model.Role = user.Role;
            //user.FirstName = model.FirstName;
            //user.SecondName = model.SecondName;
            //user.LastName = model.LastName;
            //user.PhoneNumber = model.PhoneNumber;
            return await Update(user);
        }

        public async Task<User> ExtendRole(int userId, string inp)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> UpdateRole(int id, string role)
        {
            var userModel = await Get(id);
         //   var userModel = Mapper.Map<User>(user);
            userModel.Role = role;
            var updated = await Update(userModel);
            return updated;
        }

      
    }
}
