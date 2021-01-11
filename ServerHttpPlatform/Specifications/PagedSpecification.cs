using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    public class PagedSpecification<T> : SortSpecification<T>
    {
        public PagedSpecification(int take, int skip = 0, string sortProp=null, string sortOrder=null) : base(sortProp, sortOrder)
        {
            Query.Take(take);
            Query.Skip(skip);
        }
    }
}
