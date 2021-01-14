﻿using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IVoteService : IServiceCrudModel<Votes, int, VotesEntity>
    {
    }
    public class VoteService : ServiceCrudModel<Votes, int, VotesEntity>, IVoteService
    {
        public VoteService(IMapper mapper, IVotesRepository repository) : base(mapper, repository)
        {
        }
    }
}
