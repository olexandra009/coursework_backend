using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {

    }
    public class UserRepository :EfRepository<UserEntity>, IUserRepository
    {
        public UserRepository(PlatformDbContext context) : base(context)
        {
            
        }

    }
}
