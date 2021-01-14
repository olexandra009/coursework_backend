using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IMultimediaService : IServiceCrudModel<Multimedia, int, MultimediaEntity>
    {

    }
     
    public class MultimediaService : ServiceCrudModel<Multimedia, int, MultimediaEntity>, IMultimediaService
    {
        public MultimediaService(IMapper mapper, IMultimediaRepository repository) : base(mapper, repository)
        {
        }


        protected string UploadMultimedia(string file)
        {
            //todo write method that will be upload file and return url
            return "url of object";
        }
    }
}
