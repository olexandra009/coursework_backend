using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query for getting users from organization
    /// </summary>
    public class UsersByOrganizationIdSpecification : PagedSpecification<UserEntity>
    {
        /// <summary>
        /// Creates specification query for getting users from organization
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="query"></param>
        public UsersByOrganizationIdSpecification(int organizationId, PagedSortListQuery query) : base(query.Take, 
                                                                                                       query.Skip, 
                                                                                                       query.SortProp, 
                                                                                                       query.SortOrder)
        {
            Query.Where(u => u.UserOrganizationId == organizationId);
        }
    }
}
