﻿using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IOrganizationRepository
    {

    }
    public class OrganizationRepository:EfRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(PlatformDbContext context):base(context)
        {
            
        }
    }
}
