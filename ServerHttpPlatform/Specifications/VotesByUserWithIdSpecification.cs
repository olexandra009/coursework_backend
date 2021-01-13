using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query for getting list of votes by user Id
    /// </summary>
    public class VotesByUserWithIdSpecification : Specification<VotesEntity>
    {
        /// <summary>
        /// Creates specification query for getting list of votes by user Id
        /// </summary>
        /// <param name="userId"></param>
        public VotesByUserWithIdSpecification(int userId)
        {
            Query.Where(v => v.UserId == userId).Include(v => v.Petition);

        }
    }
}
