using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IVotesRepository : IRepository<VotesEntity>
    {
    }
    public class VotesRepository:EfRepository<VotesEntity>, IVotesRepository
    {
        public VotesRepository(PlatformDbContext context):base(context)
        {
            
        }
    }
}
