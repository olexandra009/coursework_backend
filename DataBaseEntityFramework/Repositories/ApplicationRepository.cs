using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IApplicationRepository
    {
    }
    public class ApplicationRepository: EfRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(PlatformDbContext context):base(context)
        {
            
        }
    }
}
