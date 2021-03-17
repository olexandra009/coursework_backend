using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.EntityFrameworkCore;

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
        /// <param name="role"></param>
        /// <param name="query"></param>
        public UserByRoleSpecification(string role, PagedSortListQuery query) : base(query.Take,
            query.Skip,
            query.SortProp,
            query.SortOrder)
        {
            string rolePatter = "%" + role + "%";
            switch (role)
            {
                case "SuperUser":
                    Query.Where(x => EF.Functions.Like(x.Role, rolePatter));
                    break;
                case "User":
                    Query.Where(x => EF.Functions.Like(x.Role, rolePatter));
                    break;
                 default:
                     Query.Where(x => EF.Functions.Like(x.Role, rolePatter));
                     break;
            }


        }


        //private Func<UserEntity, string, bool> _compareUserRole = (u, role) =>
        //{
        //    string[] userRoles = u.Role.ToLower().Split(", ");
        //    string[] compareRoles = role.ToLower().Split(", ");
        //    int userRoleCount = userRoles.Length;
        //    int compareRoleCount = compareRoles.Length;
        //    int exceptCount = userRoles.Except(compareRoles).Count();
        //    bool res = exceptCount == (userRoleCount - compareRoleCount);
        //    return res;
        //};

        //private bool CompareUsersRole(string userRole, string role)
        //{
            
        //    string[] userRoles = userRole.ToLower().Split(", ");
        //    string[] compareRoles = role.ToLower().Split(", ");
        //    int userRoleCount = userRoles.Length;
        //    int compareRoleCount = compareRoles.Length;

        //    int exceptCount = userRoles.Except(compareRoles).Count();

        //    return exceptCount == userRoleCount - compareRoleCount;
        //}
    }
}
