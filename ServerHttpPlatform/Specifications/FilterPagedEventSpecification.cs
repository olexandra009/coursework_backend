using System;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    ///  Specification query for get list of events filter by end date
    /// </summary>
    public class FilterPagedEventSpecification:PagedSpecification<EventEntity>
    {
        /// <summary>
        /// Creates specification query for get list of events filter by end date
        /// </summary>
        /// <param name="filter">allow values active, pass </param>
        /// <param name="query"></param>
        public FilterPagedEventSpecification(string filter, PagedSortListQuery query) 
                                                          : base(query.Take, 
                                                                 query.Skip, 
                                                                 query.SortProp,
                                                                 query.SortOrder)
        {
            if (string.IsNullOrEmpty(filter)) return;
            switch (filter.ToLower())
            {
                case "active":
                    Query.Where(e => e.EndDate >= DateTime.Now);
                    break;
                case "pass":
                    Query.Where(e => e.EndDate < DateTime.Now);
                    break;
                default:
                    throw new ArgumentException();
            }
           
        }
    }
}
