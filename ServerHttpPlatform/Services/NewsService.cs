using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface INewsService:IServiceCrudModel<News, int, NewsEntity>
    {

    }
    public class NewsService : ServiceCrudModel<News, int, NewsEntity>
    {
        public NewsService(IMapper mapper, IRepository<NewsEntity> repository) : base(mapper, repository)
        {
            
        }

        public override Task<News> Update(News model)
        {
            model.Edited = true;
            return base.Update(model);
        }
    }
}
