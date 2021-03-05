using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IUserService : IServiceCrudModel<User,int,UserEntity>
    {
        Task<User> Registration(User user);
        Task<User> Login(string login, string password);
        Task<User> UpdateRole(int id, string role);
        Task<User> ConfirmEmail(int userId, string code);
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
            Organization organization = null;
            if (user.UserOrganizationId != null)
            {
                organization = await OrganizationService.Get((int) user.UserOrganizationId);
                user.UserOrganization = organization;
                user.UserOrganizationName = organization.Name;
            }
            return user;
        }

        public async Task<User> Registration(User user)
        {
            user.EmailConfirm = false;
            user.Role = "User";
            var created = await Create(user);
            int userId = created.Id;
            string login = created.Login;
            var emailConfirm = await EmailService.CreateNewInstance(login, userId);
            var code = HttpUtility.UrlEncode(emailConfirm.Code);
            var url = "https://"+ $"localhost:44336/confirm_email?id={userId}&code={code}";
            await SendEmailService.SendConfirmLetter(user.Email, $"{user.FirstName} {user.SecondName} {user.LastName}", url);
            return created;
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
