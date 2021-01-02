using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IEventRepository
    {
    }
    public class EventRepository : EfRepository<Event>, IEventRepository
    {
        public EventRepository(PlatformDbContext context):base(context)
        {
            
        }
    }
}
