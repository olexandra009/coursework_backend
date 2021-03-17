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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : CrudControllerBase<VotesDTO, Votes, VotesEntity, int>
    {
        protected IVoteService VoteService => (VoteService) Service;
        public VotesController(IVoteService service, IMapper mapper) : base(service, mapper)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("/not")]
        public override Task<ActionResult<VotesDTO>> Create(VotesDTO dto)
        {
            return base.Create(dto);
        }
   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "SuperUser,NewsAndEvents,Moderator,ApplicationAdmin,UserManager")]
        public async Task<ActionResult<VotesDTO>> Create(int userId, int petitionId)
        {
            Claim i = HttpContext.User.Claims.FirstOrDefault(s => s.Type == "person/user/identificate");
            if (i == null) return Unauthorized();
            if (string.IsNullOrEmpty(i.Value)) return Unauthorized();
            int update = int.Parse(i.Value);
            if (update != userId) return Unauthorized();
            VotesDTO dto = new VotesDTO()
            {
                PetitionId = petitionId,
                UserId = userId
            };

            return await base.Create(dto);
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "SuperUser,NewsAndEvents,Moderator,ApplicationAdmin,UserManager")]
        public override Task<ActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [HttpGet("/votes_number")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVotesNumber(int petitionId)
        {
            var result = await VoteService.Count(new VotesForPetitionWithIdSpecification(petitionId));
            return Ok(new { count = result });
        }

    }
}
