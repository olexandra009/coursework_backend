using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IMultimediaService : IServiceCrudModel<Multimedia, int, MultimediaEntity>
    {
    }
    //todo create specification to get by event/application/news id 
    public class MultimediaService : ServiceCrudModel<Multimedia, int, MultimediaEntity>
    {
        public MultimediaService(IMapper mapper, IRepository<MultimediaEntity> repository) : base(mapper, repository)
        {
        }
    }
}
