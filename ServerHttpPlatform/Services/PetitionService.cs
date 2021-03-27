using System;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using Microsoft.Extensions.Configuration;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IPetitionService : IServiceCrudModel<Petition, int, PetitionEntity>
    {
        public int SuccessfulMinimumVotesNumber();
        Task SendEmailAnswer(Petition petition);
    }

    public class PetitionService : ServiceCrudModel<Petition, int, PetitionEntity>, IPetitionService
    {
        protected ISendEmailService EmailService;
        protected IUserService UserService;
        protected IVoteService VoteService;
        private readonly int _minimumVotesNumber;
        public PetitionService(IMapper mapper, IConfiguration configuration, IVoteService voteService,
                                IUserService userService, IPetitionRepository repository, ISendEmailService emailService) : base(mapper, repository)
        {
            VoteService = voteService;
            UserService = userService;
            EmailService = emailService;
            _minimumVotesNumber = Convert.ToInt32(configuration.GetSection("AppConfiguration")["SuccessfulVotesNumber"]);
        }

        public override async Task<Petition> Get(int id)
        {
            var petition = await base.Get(id);
            if (petition == null) return null;
            petition.Author = await UserService.Get(petition.AuthorId);
            petition.UserVotes = await VoteService.List(new VotesForPetitionWithIdSpecification(petition.Id));
            foreach (var vote in petition.UserVotes)
            {
                vote.User = await UserService.Get(vote.UserId);
            }
            return petition;
        }

        public async Task SendEmailAnswer(Petition petition)
        {
            var author = await UserService.Get(petition.AuthorId);
            if (author == null) return;
            await EmailService.SendAnswerPetitionLetter(author.Email, author.FirstName, petition.Header,
                petition.Answer);

        }

        public int SuccessfulMinimumVotesNumber()
        {
            return _minimumVotesNumber;
        }
    }
}

