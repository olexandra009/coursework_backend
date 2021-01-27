using System.Linq;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query to get users with specific role
    /// </summary>
    public class UserByRoleSpecification: PagedSpecification<UserEntity>
    {
        /// <summary>
        /// Creates specification query to get users with specific role
        /// </summary>
        /// <param name="role">can be several roles separate by ', '</param>
        /// <param name="query"></param>
        public UserByRoleSpecification(string role, PagedSortListQuery query) : base(query.Take,
                                                                                    query.Skip,
                                                                                    query.SortProp,
                                                                                    query.SortOrder)
        {
            Query.Where(u=>CompareUsersRole(u.Role, role));
        }

        private bool CompareUsersRole(string userRole, string role)
        {
            
            string[] userRoles = userRole.ToLower().Split(", ");
            string[] compareRoles = role.ToLower().Split(", ");
            int userRoleCount = userRoles.Length;
            int compareRoleCount = compareRoles.Length;

            int exceptCount = userRoles.Except(compareRoles).Count();

            return exceptCount == userRoleCount - compareRoleCount;
        }
    }
}
