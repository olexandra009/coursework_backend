using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common
{
    public interface IServiceListModel<TModel, TEntity>
    {
        Task<List<TModel>> List();
        //todo: maybe methods with listQuery should be added 
        Task<List<TModel>> List(ISpecification<TEntity> specification);
        Task<int> Count(ISpecification<TEntity> specification);
    }
}
