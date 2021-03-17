using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//summary should be done
//  add authorization to endpoints
//  overload edit to allow changing multimedia (delete old and upload new)  

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : CrudControllerBase<NewsDTO,News,NewsEntity, int>
    {
        protected INewsService NewsService => (NewsService) Service;
        public NewsController(INewsService service, IMapper mapper) : base(service, mapper)
        {
        }

        #region GetList
        /// <summary>
        /// Get list of news sorted by date of creation by default
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public override Task<ListResult<NewsDTO>> GetList(PagedSortListQuery query)
        {
            if (string.IsNullOrEmpty(query.SortProp))
                query.SortProp = "DateTimeCreation";
            return base.GetList(query);
        }
        /// <summary>
        /// Get list of news created by organization sorted by date of creation by default
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/news_by_organization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ListResult<NewsDTO>>> FilteredByOrganization(int organizationId, [FromQuery]PagedSortListQuery query)
        {
            if (string.IsNullOrEmpty(query.SortProp))
                query.SortProp = "DateTimeCreation";
            var modelList = await NewsService.List(new CreatedNewsByOrganizationIdSpecification(organizationId, query));
            var result = new ListResult<NewsDTO>()
            {
                Result = Mapper.Map<List<NewsDTO>>(modelList),
                Total = await NewsService.Count(
                    new CreatedNewsByOrganizationIdSpecification(organizationId, query.TakeAll()))
            };
            return result;
        }
        #endregion

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "NewsAndEvents")]
        public override Task<ActionResult<NewsDTO>> Create(NewsDTO dto)
        {
            return base.Create(dto);
        }


        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "NewsAndEvents,Moderator")]
        public override async Task<ActionResult<NewsDTO>> Update(int id, NewsDTO dto)
        {
            List<Claim> roles = HttpContext.User.Claims.Where(s => s.Type == ClaimsIdentity.DefaultRoleClaimType).ToList();
            bool moderator = false;
            roles.ForEach(claim =>
            {
                if (claim.Value == "Moderator")
                    moderator = true;
            });
            if (!moderator)
            {
                Claim i = HttpContext.User.Claims.FirstOrDefault(s => s.Type == "person/user/identificate");
                if (i == null) return Unauthorized();
                if (string.IsNullOrEmpty(i.Value)) return Unauthorized();
                int update = int.Parse(i.Value);
                if (update != dto.AuthorId) return Unauthorized();
            }
            return await base.Update(id, dto);
        }

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Moderator")]
        public override Task<ActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

    }
}
