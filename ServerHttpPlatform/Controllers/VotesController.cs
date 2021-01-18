using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
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
        public Task<ActionResult<VotesDTO>> Create(int userId, int petitionId)
        {
            VotesDTO dto = new VotesDTO()
            {
                PetitionId = petitionId,
                UserId = userId
            };

            return base.Create(dto);
        }
    }
}
