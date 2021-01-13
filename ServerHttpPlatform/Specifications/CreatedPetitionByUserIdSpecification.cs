using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{   
    /// <summary>
    /// Specification query for get list of petition created by user with userId
    /// </summary>
    public class CreatedPetitionByUserIdSpecification : PagedSpecification<PetitionEntity>
    {
        /// <summary>
        /// Creates specification query for get list of petition created by user with userId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="query"></param>
        public CreatedPetitionByUserIdSpecification(int userId, PagedSortListQuery query) : base(query.Take, 
                                                                                                 query.Skip, 
                                                                                                 query.SortProp, 
                                                                                                 query.SortOrder)
        {
            Query.Where(p => p.AuthorId == userId);
        }
    }
}
