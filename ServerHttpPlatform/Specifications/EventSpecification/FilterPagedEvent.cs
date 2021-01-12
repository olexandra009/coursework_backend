using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.EventSpecification
{
    public class FilterPagedEvent:PagedSpecification<EventEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter">allow values active, pass </param>
        /// <param name="query"></param>
        public FilterPagedEvent(string filter, PagedSortListQuery query) 
                                                          : base(query.Take, 
                                                                 query.Skip, 
                                                                 query.SortProp,
                                                                 query.SortOrder)
        {
            if (string.IsNullOrEmpty(filter)) return;
            switch (filter.ToLower())
            {
                case "active":
                    Query.Where(e => e.EndDate <= DateTime.Now);
                    break;
                case "pass":
                    Query.Where(e => e.EndDate > DateTime.Now);
                    break;
                default:
                    throw new ArgumentException();
            }
           
        }
    }
}
