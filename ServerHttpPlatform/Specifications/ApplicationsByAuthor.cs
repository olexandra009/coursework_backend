using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query for getting list of application by author id
    /// </summary>
    public class ApplicationsByAuthor : PagedSpecification<ApplicationEntity>
    {
        /// <summary>
        /// Creates specification query for getting list of application by author id
        /// </summary>
        /// <param name="userId">id of application's author</param>
        /// <param name="query"></param>
        public ApplicationsByAuthor(int userId, PagedSortListQuery query) : base(query.Take, query.Skip, query.SortProp, query.SortOrder)
        {
            Query.Where(a => a.AuthorId == userId);
        }
    }
}
