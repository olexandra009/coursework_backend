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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//summary should be done:
//  do we need methods that return petition voted by person?
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

        [AllowAnonymous]
        public override async Task<ActionResult<PetitionDTO>> Get(int id)
        {
            var petition = await base.Get(id);
            petition.Value.VotesNumber = petition.Value.UserVotes.Count;
            return petition;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<PetitionDTO>> Update(int id, PetitionDTO dto)
        {
            return base.Update(id, dto);
        }

        [HttpPut("/api/Petition/minimum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public ActionResult<int> PetitionCount()
        {
            return PetitionService.SuccessfulMinimumVotesNumber();
        }

        [HttpPut("/api/Petition/addAnswer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "ApplicationAdmin")]
        public async Task<ActionResult<PetitionDTO>> AddAnswer([FromQuery]int id, PetitionDTO dto)
        {
            var petition = await PetitionService.Get(id);
            if (petition == null) return NotFound();
            if (petition.Answer != null) return Conflict();
            int votes = petition.UserVotes.Count;
            int minimum = PetitionService.SuccessfulMinimumVotesNumber();
            if (votes < minimum) return Forbid();
            var updated = Mapper.Map<Petition>(dto);
            updated.AuthorId = petition.AuthorId;
            updated.FinishDate = petition.FinishDate;
            updated.StarDate = petition.StarDate;
            updated.Text = petition.Text;
            updated.Header = petition.Header;
            await PetitionService.SendEmailAnswer(updated);
            return await Update(id, Mapper.Map<PetitionDTO>(updated));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        /// <summary>
        /// Get list of petition sorted by start date by default
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public override async Task<ListResult<PetitionDTO>> GetList(PagedSortListQuery query)
        {
            if (string.IsNullOrEmpty(query.SortProp))
                query.SortProp = "StarDate";
            //var list = await base.GetList(query);
            //list.Result.ForEach(async p=>p.VotesNumber = await PetitionService.GetVotesNumber(p.Id));
            return await base.GetList(query); 
        }
        

        /// <summary>
        /// Get filtered by status petition
        /// </summary>
        /// <param name="timeStatus">allow values active, act, close, cls</param>
        /// <param name="votesStatus">allow values succ, successful, unsucc, unsuccessful</param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/filter_by_status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ListResult<PetitionDTO>> FilteredByStatus(string timeStatus, string votesStatus, [FromQuery]PagedSortListQuery query)
        {

            var resultModel =
                await PetitionService.List(new FilterStatusPetitionSpecification(PetitionService.SuccessfulMinimumVotesNumber(), query, timeStatus, votesStatus));
          //  var resultDto =
           //     Mapper.Map<List<PetitionDTO>>(resultModel);
           // resultDto.ForEach(async p => p.VotesNumber = await PetitionService.GetVotesNumber(p.Id));
            var result = new ListResult<PetitionDTO>()
            {
                Result = Mapper.Map<List<PetitionDTO>>(resultModel),
                Total = await PetitionService.Count(
                    new FilterStatusPetitionSpecification(PetitionService.SuccessfulMinimumVotesNumber(), query.TakeAll(), timeStatus, votesStatus))
            };
            return result;
        }
        /// <summary>
        /// Get list of petition created by user with id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/filter_by_author")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ListResult<PetitionDTO>> FilteredByAuthor(int userId, [FromQuery]PagedSortListQuery query)
        {
            var resultModel =
                await PetitionService.List(new CreatedPetitionByUserIdSpecification(userId, query));
           // var resultDto =
           // resultDto.ForEach(async p => p.VotesNumber = await PetitionService.GetVotesNumber(p.Id));
            var result = new ListResult<PetitionDTO>()
            {
                Result = Mapper.Map<List<PetitionDTO>>(resultModel),
                Total = await PetitionService.Count(new CreatedPetitionByUserIdSpecification(userId, query.TakeAll()))
            };
            return result;
        }


        [HttpGet("/filter_author_status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ListResult<PetitionDTO>> FilteredByAuthorAndStatus(int userId, string timeStatus, string voteStatus, [FromQuery] PagedSortListQuery query)
        {
            var resultModel =
                await PetitionService.List(new FilterPetitionByStatusAndUserIdSpecification(PetitionService.SuccessfulMinimumVotesNumber(), userId, query, timeStatus, voteStatus));
            // var resultDto =
            // resultDto.ForEach(async p => p.VotesNumber = await PetitionService.GetVotesNumber(p.Id));
            var result = new ListResult<PetitionDTO>()
            {
                Result = Mapper.Map<List<PetitionDTO>>(resultModel),
                Total = await PetitionService.Count(new FilterPetitionByStatusAndUserIdSpecification(PetitionService.SuccessfulMinimumVotesNumber(), userId, query.TakeAll(), timeStatus, voteStatus))
            };
            return result;
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "SuperUser,NewsAndEvents,Moderator,ApplicationAdmin,UserManager")]
        public override Task<ActionResult<PetitionDTO>> Create(PetitionDTO dto)
        {
            return base.Create(dto);
        }
    }
}
