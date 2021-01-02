using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IPetitionRepository
    {

    }
    public class PetitionRepository: EfRepository<Petition>, IPetitionRepository
    {
        public PetitionRepository(PlatformDbContext context) : base(context)
        {
            
        }

    }
}
