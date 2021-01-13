using System;
using System.Linq.Expressions;
using Ardalis.Specification;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common
{
    public class SortSpecification<T> : Specification<T>
    {
        ///<param name="sortProp">name of property to sort</param>
        ///<param name="sortOrder">order of sorting allow values: asc, desc </param>
        public SortSpecification(string sortProp, string sortOrder)
        {
            if (string.IsNullOrEmpty(sortOrder) || string.IsNullOrEmpty(sortProp)) return;
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            MemberExpression property = Expression.Property(parameter, sortProp);
            UnaryExpression expression = Expression.Convert(property, typeof(object));
            var sortExpression = Expression.Lambda<Func<T, object>>(expression, parameter);

            switch (sortOrder.ToLower())
            {
                case "asc":
                    Query.OrderBy(sortExpression);
                    break;
                case "desc":
                    Query.OrderByDescending(sortExpression);
                    break;
                default:
                    throw new ArgumentException(message: "Invalid value for sortOrder parameter");
            }
        }

    }
}
