using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query for get list of application filtered by statusModel
    /// </summary>
    public class FilterByStatusApplicationSpecification : PagedSpecification<ApplicationEntity>
    {
        /// <summary>
        /// Creates specification query for get list of application filtered by statusModel
        /// </summary>
        /// <param name="status"></param>
        /// <param name="query"></param>
        public FilterByStatusApplicationSpecification(Status status, PagedSortListQuery query) : base(query.Take, 
                                                                                                      query.Skip, 
                                                                                                      query.SortProp, 
                                                                                                      query.SortOrder)
        {
            Query.Where(a => a.Status == status);
        }
    }
}
