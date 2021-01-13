using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query for getting list of events created by organization with id
    /// </summary>
    public class CreatedEventsOrganizationIdSpecification : PagedSpecification<EventEntity>
    {
        /// <summary>
        /// Create specification query for getting list of events created by organization with id
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="query"></param>
        //todo test this specification
        public CreatedEventsOrganizationIdSpecification(int organizationId, PagedSortListQuery query) : base(query.Take,
                                                                                                             query.Skip,
                                                                                                             query.SortProp,
                                                                                                             query.SortOrder)
        {
            Query.Where(e => e.Author.UserOrganizationId == organizationId);
        }
    }
}
