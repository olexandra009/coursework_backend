using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query for get list of multimedia for news
    /// </summary>
    public class MultimediaByNewsIdSpecification : Specification<MultimediaEntity>
    {
        /// <summary>
        /// Creates specification query for get list of multimedia for event
        /// </summary>
        /// <param name="newsId"></param>
        public MultimediaByNewsIdSpecification(int newsId)
        {
            Query.Where(m => m.NewsId == newsId);
        }
    }
}