using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    public class SortedEventsByOrganizationAndTimeSpecification : PagedSpecification<EventEntity>
    {
        public SortedEventsByOrganizationAndTimeSpecification(int orgId, string filter, PagedSortListQuery query) : base(query.Take, query.Skip, query.SortProp, query.SortOrder)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                switch (filter.ToLower())
                {
                    case "active":
                        Query.Where(e => (e.EndDate >= DateTime.Now) && (e.Author.UserOrganizationId == orgId));
                        break;
                    case "pass":
                        Query.Where(e => e.EndDate < DateTime.Now && e.Author.UserOrganizationId == orgId);
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

          
        }
    }
}
