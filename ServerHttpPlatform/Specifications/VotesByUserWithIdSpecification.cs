using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query for getting list of votes by user Id
    /// </summary>
    public class VotesByUserWithIdSpecification : PagedSpecification<VotesEntity>
    {
        /// <summary>
        /// Creates specification query for getting list of votes by user Id
        /// </summary>
        /// <param name="userId"></param>
        public VotesByUserWithIdSpecification(int userId, PagedSortListQuery query) : base(query.Take,
                                                                                            query.Skip,
                                                                                            query.SortProp,
                                                                                            query.SortOrder)
        {
            Query.Where(v => v.UserId == userId).Include(v => v.Petition);

        }
    }
}
