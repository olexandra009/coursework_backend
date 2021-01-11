using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IVoteService : IServiceCrudModel<Votes, int, VotesEntity>
    {
    }
    //todo specification for votes count
    public class VoteService : ServiceCrudModel<Votes, int, VotesEntity>, IVoteService
    {
        public VoteService(IMapper mapper, IRepository<VotesEntity> repository) : base(mapper, repository)
        {
        }
    }
}
