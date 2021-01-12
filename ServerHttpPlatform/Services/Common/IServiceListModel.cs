using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common
{
    public interface IServiceListModel<TModel, TEntity>
    {
        Task<List<TModel>> List();
        Task<List<TModel>> List(PagedSortListQuery query);
        Task<int> Count(PagedSortListQuery query);
        Task<List<TModel>> List(ISpecification<TEntity> specification);
        Task<int> Count(ISpecification<TEntity> specification);
    }
}
