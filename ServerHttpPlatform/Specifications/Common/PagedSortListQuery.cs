using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common
{
    public class PagedSortListQuery
    {
        const int DefaultSkip = 0;
        const int DefaultTake = 10;
        const string DefaultOrder = "asc";
        
        public int Skip { get; set; } = DefaultSkip;
        public int Take { get; set; } = DefaultTake;
        public string SortProp { get; set;}
        public string SortOrder { get; set;} = DefaultOrder;

        /// <summary>
        /// Query for getting entities without sorting using default skip and take 
        /// </summary>
        PagedSortListQuery()
        {
            
        }
       
        /// <summary>
        /// Query for getting entities by default skip and take with sort 
        /// </summary>
        /// <param name="sortProp">property to sort</param>
        /// <param name="sortOrder">allows values asc, desc</param>
        PagedSortListQuery(string sortProp, string sortOrder = DefaultOrder)
        {
            SortOrder = sortProp;
            SortOrder = sortOrder;
        }
        /// <summary>
        /// Query for getting entities
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="sortProp">property to sort</param>
        /// <param name="sortOrder">allows values asc, desc</param>
        PagedSortListQuery(int take, int skip, string sortProp, string sortOrder)
        {
            Take = take;
            Skip = skip;
            SortProp = sortProp;
            SortOrder = sortOrder;
        }

        public void GetAllEntities()
        {
            Take = Int32.MaxValue;
        }
    }
}
