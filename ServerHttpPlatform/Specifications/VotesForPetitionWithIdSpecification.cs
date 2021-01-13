using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query for getting list of votes by petitionId
    /// </summary>
    public class VotesForPetitionWithIdSpecification : Specification<VotesEntity>
    {
        /// <summary>
        /// Creates specification query for getting list of votes by petitionId
        /// </summary>
        /// <param name="petitionId"></param>
        public VotesForPetitionWithIdSpecification(int petitionId)
        { 
            //todo try without include
           Query.Where(v => v.PetitionId == petitionId).Include(v=>v.User);

        }
    }
}
