using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.PetitionSpecification
{
    public class CreatedPetitionByUserIdSpecification : PagedSpecification<PetitionEntity>
    {
        public CreatedPetitionByUserIdSpecification(int userId, PagedSortListQuery query) : base(query.Take, 
                                                                                                 query.Skip, 
                                                                                                 query.SortProp, 
                                                                                                 query.SortOrder)
        {
            Query.Where(p => p.AuthorId == userId);
        }
    }
}
