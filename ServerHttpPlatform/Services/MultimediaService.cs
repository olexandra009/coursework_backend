using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using Org.BouncyCastle.Asn1.Cms;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IMultimediaService : IServiceCrudModel<Multimedia, int, MultimediaEntity>
    {
        Task<Multimedia> UploadMultimedia(Multimedia multimedia, int from, int arrayId);
        Task DeleteMultimediaFromS3(Multimedia multimedia);
    }
   
    public class MultimediaService : ServiceCrudModel<Multimedia, int, MultimediaEntity>, IMultimediaService
    {
        protected IUploadMultimediaService UploadService;
        public MultimediaService(IMapper mapper, IUploadMultimediaService service, IMultimediaRepository repository) : base(mapper, repository)
        {
            UploadService = service;
        }

        public override async Task Delete(int id)
        {
            Console.WriteLine("In delete");
            var multi = await Get(id);
            string uri = multi.Url;
            await UploadService.DeleteImageFromS3(uri);
            await base.Delete(id);
        }

        public async Task DeleteMultimediaFromS3(Multimedia multimedia)
        {
            await UploadService.DeleteImageFromS3(multimedia.Url);
        }

        public async Task<Multimedia> UploadMultimedia(Multimedia multimedia, int from, int arrayId)
        { 
            var file = multimedia.Url;
            multimedia.Url = String.Empty;
            var time = DateTime.Now.GetHashCode();
            //  var multimediaCreated = await Create(multimedia);
            var time2 = DateTime.Now.GetHashCode();
            var fileName = $"image{arrayId}{time}{time2}.png";
            string folderName;
            switch (from)
            {
                case 1:
                    folderName = "news";
                    break;
                case 2:
                    folderName = "events";
                    break;
                case 3:
                    folderName = "applications";
                    break;
                default:
                    folderName = "default";
                    break;
            }

            string uri = await UploadService.UploadImage(file, folderName, fileName);

            //var bytes = Convert.FromBase64String(file);
            //TODO write method that will be upload file and return url
            multimedia.Url = uri;
           // multimediaCreated.Url = uri;
           // var multiUpdated = await Update(multimedia);
            return multimedia;
        }
    }
}
