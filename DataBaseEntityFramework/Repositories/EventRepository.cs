using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IEventRepository:IRepository<EventEntity>
    {
    }
    public class EventRepository : EfRepository<EventEntity>, IEventRepository
    {
        public EventRepository(PlatformDbContext context):base(context)
        {
            
        }
    }
}
