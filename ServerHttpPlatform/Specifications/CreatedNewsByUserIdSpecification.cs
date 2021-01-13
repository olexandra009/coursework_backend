using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query for get list of news created by user with userId
    /// </summary>
    public class CreatedNewsByUserIdSpecification : Specification<NewsEntity>
    {
        /// <summary>
        /// Creates specification query for get list of petition created by user with userId
        /// </summary>
        /// <param name="userId"></param>
        public CreatedNewsByUserIdSpecification(int userId)
        {
            Query.Where(n => n.AuthorId == userId);
        }
    }
}
