using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface INewsService:IServiceCrudModel<News, int, NewsEntity>
    {

    }

    public class NewsService : ServiceCrudModel<News, int, NewsEntity>, INewsService
    {
        protected IMultimediaService MultimediaService;
        protected IUserService UserService;
        public NewsService(IMapper mapper, IUserService userService, IMultimediaService multimediaService, INewsRepository repository) : base(mapper, repository)
        {
            UserService = userService;
            MultimediaService = multimediaService;
        }

        public override async Task<News> Get(int id)
        {
            var news = await base.Get(id);
            news.Multimedias = await MultimediaService.List(new MultimediaByNewsIdSpecification(news.Id));
            news.Author = await UserService.Get(news.AuthorId);
            return news;

        }

        public override async Task<List<News>> List(ISpecification<NewsEntity> specification)
        {
            var models = await  base.List(specification);
            foreach (var newsModel in models)
            {
                newsModel.Multimedias = await MultimediaService.List(new MultimediaByNewsIdSpecification(newsModel.Id));
                newsModel.Author = await UserService.Get(newsModel.AuthorId);
            }

            return models;
        }

        public override async Task<News> Create(News model)
        {
            List<Multimedia> updatedList = new List<Multimedia>();
            foreach (var multimedia in model.Multimedias)
            {
                updatedList.Add(await MultimediaService.UploadMultimedia(multimedia));
            }
            model.Multimedias = updatedList;
            return await base.Create(model);
        }

        public override Task<News> Update(News model)
        {
            model.Edited = true;
            return base.Update(model);
        }
    }
}
