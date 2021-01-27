
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query for getting list of application by answerer id
    /// </summary>
    public class ApplicationByAnswererIdSpecification : PagedSpecification<ApplicationEntity>
    {
        /// <summary>
        /// Creates specification query for getting list of application by answerer id
        /// </summary>
        /// <param name="userId">id of application's answerer</param>
        /// <param name="query">object that include take, skip and sort parameters</param>
        /// <param name="status"></param>
        public ApplicationByAnswererIdSpecification(int? userId, PagedSortListQuery query, Status status = Status.NullStatus) : base(query.Take, query.Skip, query.SortProp, query.SortOrder)
        {
            Query.Where(a => a.AnswerId == userId);
            if (status == Status.NullStatus) return;
            Query.Where(a => a.Status == status);
        }
    }
}
