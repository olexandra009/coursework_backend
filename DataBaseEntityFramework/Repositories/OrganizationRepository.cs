using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IOrganizationRepository
    {

    }
    public class OrganizationRepository:EfRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(PlatformDbContext context):base(context)
        {
            
        }
    }
}
