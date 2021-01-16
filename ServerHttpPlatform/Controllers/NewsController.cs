using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers
{
    public class NewsController : CrudControllerBase<NewsDTO,News,NewsEntity, int>
    {
        protected INewsService NewsService => (NewsService) Service;
        public NewsController(INewsService service, IMapper mapper) : base(service, mapper)
        {
        }

        public override Task<ListResult<NewsDTO>> GetList(PagedSortListQuery query)
        {
            if (string.IsNullOrEmpty(query.SortProp))
                query.SortProp = "DateTimeCreation";
            return base.GetList(query);
        }

        [HttpGet("/news_by_organization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ListResult<NewsDTO>>> FilteredByOrganization(int organizationId,
            PagedSortListQuery query)
        {
            var modelList = await NewsService.List(new CreatedNewsByOrganizationIdSpecification(organizationId, query));
            var result = new ListResult<NewsDTO>()
            {
                Result = Mapper.Map<List<NewsDTO>>(modelList),
                Total = await NewsService.Count(
                    new CreatedNewsByOrganizationIdSpecification(organizationId, query.TakeAll()))
            };
            return result;
        }
    }
}
