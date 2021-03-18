using System.Threading.Tasks;
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

        public override async Task UpdateAsync(UserEntity entity)
        {
            var orgId = entity.UserOrganizationId;
            _dbContext.Set<UserEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            if (orgId == entity.UserOrganizationId) return;
            entity.UserOrganizationId = orgId;
            _dbContext.Set<UserEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            
        }
    }
}
