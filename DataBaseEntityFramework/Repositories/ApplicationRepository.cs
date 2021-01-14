using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IApplicationRepository : IRepository<ApplicationEntity>
    {
    }
    public class ApplicationRepository: EfRepository<ApplicationEntity>, IApplicationRepository
    {
        public ApplicationRepository(PlatformDbContext context):base(context)
        {
            
        }
    }
}
