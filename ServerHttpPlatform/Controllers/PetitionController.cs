using System;
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
    [Route("api/[controller]")]
    [ApiController]
    public class PetitionController : CrudControllerBase<PetitionDTO, Petition, PetitionEntity, int>
    {
        protected IPetitionService PetitionService => (PetitionService)Service;
        public PetitionController(IPetitionService service, IMapper mapper) : base(service, mapper)
        {
        }
       
        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<PetitionDTO>> Update(int id, PetitionDTO dto)
        {
            return base.Update(id, dto);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task Delete(int id)
        {
            return base.Delete(id);
        }

        public override Task<ListResult<PetitionDTO>> GetList(PagedSortListQuery query)
        {
            if (string.IsNullOrEmpty(query.SortProp))
                query.SortProp = "StarDate";
            return base.GetList(query);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeStatus">allow values active, act, close, cls</param>
        /// <param name="votesStatus">allow values succ, successful, unsucc, unsuccessful</param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/filter_by_status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ListResult<PetitionDTO>> FilteredByStatus(string timeStatus, string votesStatus, PagedSortListQuery query)
        {
            var resultModel =
                await PetitionService.List(new FilterStatusPetitionSpecification(query, timeStatus, votesStatus));
            var result = new ListResult<PetitionDTO>()
            {
                Result = Mapper.Map<List<PetitionDTO>>(resultModel),
                Total = await PetitionService.Count(
                    new FilterStatusPetitionSpecification(query.TakeAll(), timeStatus, votesStatus))
            };
            return result;
        }

        [HttpGet("/filter_by_author")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ListResult<PetitionDTO>> FilteredByAuthor(int userId, PagedSortListQuery query)
        {
            var resultModel =
                await PetitionService.List(new CreatedPetitionByUserIdSpecification(userId, query));
            var result = new ListResult<PetitionDTO>()
            {
                Result = Mapper.Map<List<PetitionDTO>>(resultModel),
                Total = await PetitionService.Count(new CreatedPetitionByUserIdSpecification(userId, query.TakeAll()))
            };
            return result;
        }

        [HttpGet("/filter_by_voted_author")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ListResult<PetitionDTO>> FilteredByVotes(int userId, PagedSortListQuery query)
        {
            //todo do we need? create specification
            throw new NotImplementedException();
        }


    }
}
