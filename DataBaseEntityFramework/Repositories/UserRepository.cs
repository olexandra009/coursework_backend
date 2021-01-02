using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IUserRepository
    {

    }
    public class UserRepository :EfRepository<User>, IUserRepository
    {
        public UserRepository(PlatformDbContext context) : base(context)
        {
            
        }

    }
}
