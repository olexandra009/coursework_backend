using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IOrganizationRepository : IRepository<OrganizationEntity>
    {

    }
    public class OrganizationRepository:EfRepository<OrganizationEntity>, IOrganizationRepository
    {
        public OrganizationRepository(PlatformDbContext context):base(context)
        {
            
        }
    }
}
