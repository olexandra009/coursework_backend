using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Ardalis.Specification;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

       protected IUserService UserService;
        public VoteService(IMapper mapper, IUserService service, IVotesRepository repository) : base(mapper, repository)
        {
               UserService = service;
        }

        public override async Task<List<Votes>> List()
        {
            var votes = await base.List();
            votes.ForEach(vote=> vote.User = UserService.Get(vote.UserId).Result);
            return votes;
        }

        public override Task<Votes> Create(Votes model)
        {
            model.DateTimeCreated = DateTime.UtcNow;
            return base.Create(model);
        }
    }
}
