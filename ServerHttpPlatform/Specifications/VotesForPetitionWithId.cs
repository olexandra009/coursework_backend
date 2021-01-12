using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    
    public class VotesForPetitionWithId : PagedSpecification<VotesEntity>
    {
        public VotesForPetitionWithId(int petitionId, int take = 10, int skip = 0, string sortProp = null, string sortOrder = null) : base(take, skip, sortProp, sortOrder)
        {
           Query.Where(v => v.PetitionId == petitionId).Include(v=>v.User);

        }
    }
}
