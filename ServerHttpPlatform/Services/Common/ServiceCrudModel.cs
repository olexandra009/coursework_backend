using System;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common
{
    public class ServiceCrudModel<TModel, TKey, TEntity> : ServiceListModel<TModel, TEntity>, IServiceCrudModel<TModel, TKey, TEntity>
    where TEntity: class
    where TModel : IModel<TKey>
    {
        public ServiceCrudModel(IMapper mapper, IRepository<TEntity> repository) : base(mapper, repository)
        {
        }

        public virtual async Task<TModel> Get(TKey id)
        {
            TEntity entity = await Repository.GetByIdAsync(id).ConfigureAwait(false);
            TModel model = Mapper.Map<TModel>(entity);
            return model;

        }

        public virtual async Task<TModel> Create(TModel model)
        {
            TEntity entity = Mapper.Map<TEntity>(model);
            TEntity resultEntity = await Repository.AddAsync(entity).ConfigureAwait(false);
            TModel resultModel = Mapper.Map<TModel>(resultEntity);
            //todo find why should we use this
            resultModel = await Task.FromResult(resultModel).ConfigureAwait(false);
            return resultModel;
        }

        public virtual async Task<TModel> Update(TModel model)
        {
            TEntity existsEntity = await Repository.GetByIdAsync(model.Id);
            TEntity entity = Mapper.Map(model, existsEntity);
            await Repository.UpdateAsync(entity).ConfigureAwait(false);
            TModel result = Mapper.Map<TModel>(entity);
            result = await Task.FromResult(result).ConfigureAwait(false);
            return result;
        }

        public virtual async Task Delete(TKey id)
        {
            TEntity entity = await Repository.GetByIdAsync(id).ConfigureAwait(false);
            if (entity != null)
            {
                await Repository.DeleteAsync(entity).ConfigureAwait(false);
            }
        }

        public virtual async Task<bool> Exist(TKey id)
        {
            TEntity entity = await Repository.GetByIdAsync(id);
            return (entity!=null);
        }
    }
}
