﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IPetitionService : IServiceCrudModel<Petition, int, PetitionEntity>
    {
      
    }
    public class PetitionService : ServiceCrudModel<Petition, int, PetitionEntity>, IPetitionService
    {
        public PetitionService(IMapper mapper, IPetitionRepository repository) : base(mapper, repository)
        {
        }

    }
}
