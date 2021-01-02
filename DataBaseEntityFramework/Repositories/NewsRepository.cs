﻿using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{

    public interface INewsRepository
    {

    }

    public class NewsRepository : EfRepository<News>, INewsRepository
    {
       
        public NewsRepository(PlatformDbContext context) : base(context)
        {

        }

       
    }
}
