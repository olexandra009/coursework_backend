﻿using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IRightsRepository
    {
    }
    public class RightsRepository:EfRepository<Rights>, IRightsRepository
    {
        public RightsRepository(PlatformDbContext context):base(context)
        {
            
        }
    }
}