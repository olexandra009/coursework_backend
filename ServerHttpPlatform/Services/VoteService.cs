using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IVoteService : IServiceCrudModel<Votes, int, VotesEntity>
    {
       
    }
    public class VoteService : ServiceCrudModel<Votes, int, VotesEntity>, IVoteService
    {
        protected IPetitionService PetitionService;
        protected IUserService UserService;
        public VoteService(IMapper mapper, IPetitionService petitionService, IUserService userService, IVotesRepository repository) : base(mapper, repository)
        {
            PetitionService = petitionService;
            UserService = userService;
        }
        //to add user and petition
        public override async Task<List<Votes>> List(ISpecification<VotesEntity> specification)
        {
            var models = await base.List(specification);
            foreach (var vote in models)
            {
                vote.Petition = await PetitionService.Get(vote.PetitionId);
                vote.User = await UserService.Get(vote.UserId);
            }
            return models;
        }
    }
}
