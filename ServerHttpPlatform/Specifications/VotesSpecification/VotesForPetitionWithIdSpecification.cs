using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.VotesSpecification
{
    
    public class VotesForPetitionWithIdSpecification : Specification<VotesEntity>
    {
        public VotesForPetitionWithIdSpecification(int petitionId)
        {
           Query.Where(v => v.PetitionId == petitionId).Include(v=>v.User);

        }
    }
}
