using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    //todo implement methods 
    public interface IUserService : IServiceCrudModel<User,int,UserEntity>
    {
        Task Registration();
        Task<User> Login(string login, string password);
        Task<User> UpdateRole();
    }
    public class UserService:ServiceCrudModel<User, int, UserEntity>, IUserService
    {
        public UserService(IMapper mapper, IUserRepository repository) : base(mapper, repository)
        {
        }

        public async Task Registration()
        {
            throw new System.NotImplementedException();
        }


        public async Task<User> Login(string login, string password)
        {
            var user = Repository.ListAsync(new UserByLoginSpecification(login, password)).Result.FirstOrDefault();
            var result = Mapper.Map<User>(user);
            return result;

        }

        public async Task<User> UpdateRole()
        {
            throw new System.NotImplementedException();
        }
    }
}
