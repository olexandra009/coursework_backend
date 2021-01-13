using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common
{
    public class PagedSpecification<T> : SortSpecification<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="sortProp">property to sort</param>
        /// <param name="sortOrder">allows values asc, desc</param>
        public PagedSpecification(int take, int skip = 0, string sortProp=null, string sortOrder=null) : base(sortProp, sortOrder)
        {
            Query.Take(take);
            Query.Skip(skip);
        }
    }
}
