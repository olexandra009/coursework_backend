using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IEventService : IServiceCrudModel<Event, int, EventEntity>
    {

    }
    public class EventService: ServiceCrudModel<Event, int, EventEntity>, IEventService
    {
        public EventService(IMapper mapper, IEventRepository repository) : base(mapper, repository)
        {
        }

        //TODO: check if such update is working
        public override Task<Event> Update(Event model)
        {
            model.Edited = true;
            return base.Update(model);
        }

    }
}
