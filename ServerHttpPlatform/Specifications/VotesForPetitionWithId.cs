using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    
    public class VotesForPetitionWithId : Specification<VotesEntity>
    {
        public VotesForPetitionWithId(int petitionId)
        {
           Query.Where(v => v.PetitionId == petitionId).Include(v=>v.User);

        }
    }
}
