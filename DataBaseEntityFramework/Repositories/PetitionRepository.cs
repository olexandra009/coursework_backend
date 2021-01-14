using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IPetitionRepository : IRepository<PetitionEntity>
    {

    }
    public class PetitionRepository: EfRepository<PetitionEntity>, IPetitionRepository
    {
        public PetitionRepository(PlatformDbContext context) : base(context)
        {
            
        }

    }
}
