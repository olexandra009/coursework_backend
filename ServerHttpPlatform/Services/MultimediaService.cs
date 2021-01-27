using System;
using System.Threading.Tasks;
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
     //TODO delete and create multimedia with integration to S3
    public class MultimediaService : ServiceCrudModel<Multimedia, int, MultimediaEntity>, IMultimediaService
    {
        public MultimediaService(IMapper mapper, IMultimediaRepository repository) : base(mapper, repository)
        {
        }


        public async Task<Multimedia> UploadMultimedia(Multimedia multimedia, bool image=true)
        { 
            var file = multimedia.Url;
            multimedia.Url = String.Empty;

            var multimediaCreated = await base.Create(multimedia);
            
            var fileName = $"image-{multimedia.Id}.png";
            if (!image)
                fileName = $"video-{multimedia.Id}.mp4";
            var bytes = Convert.FromBase64String(file);
            //TODO write method that will be upload file and return url
            multimediaCreated.Url = fileName;
            return await base.Update(multimediaCreated);
        }
    }
}
