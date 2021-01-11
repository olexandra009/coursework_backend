
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    //todo implement methods 
    public interface IUserService : IServiceCrudModel<User,int,UserEntity>
    {
        Task Registration();
        Task Login();
        Task<User> UpdateRole();
    }
    public class UserService:ServiceCrudModel<User, int, UserEntity>, IUserService
    {
        public UserService(IMapper mapper, IRepository<UserEntity> repository) : base(mapper, repository)
        {
        }

        public async Task Registration()
        {
            throw new System.NotImplementedException();
        }

        public async Task Login()
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> UpdateRole()
        {
            throw new System.NotImplementedException();
        }
    }
}
