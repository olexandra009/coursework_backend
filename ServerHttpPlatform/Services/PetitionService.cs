using System;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using Microsoft.Extensions.Configuration;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IPetitionService : IServiceCrudModel<Petition, int, PetitionEntity>
    {
        public int SuccessfulMinimumVotesNumber();
    }
    public class PetitionService : ServiceCrudModel<Petition, int, PetitionEntity>, IPetitionService
    {
        protected IUserService UserService;
        private readonly int _minimumVotesNumber;
        public PetitionService(IMapper mapper, IConfiguration configuration,
                                IUserService userService, IPetitionRepository repository) : base(mapper, repository)
        {
            UserService = userService;
            _minimumVotesNumber = Convert.ToInt32(configuration.GetSection("AppConfiguration")["SuccessfulVotesNumber"]);
        }

        public override async Task<Petition> Get(int id)
        {
            var petition = await base.Get(id);
            petition.Author = await UserService.Get(petition.AuthorId);
            return petition;
        }

        public int SuccessfulMinimumVotesNumber()
        {
            return _minimumVotesNumber;
        }
    }
}
