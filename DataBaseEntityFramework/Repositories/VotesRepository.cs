﻿using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IVotesRepository
    {
    }
    public class VotesRepository:EfRepository<Votes>, IVotesRepository
    {
        public VotesRepository(PlatformDbContext context):base(context)
        {
            
        }
    }
}
