using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common
{
    public interface IServiceCrudModel<TModel, TKey, TEntity> : IServiceListModel<TModel, TEntity>
    {
        Task<TModel> Get(TKey id);
        Task<TModel> Create(TModel model);
        Task<TModel> Update(TModel model);
        Task Delete(TKey id);
        Task<bool> Exist(TKey id);

    }
}
