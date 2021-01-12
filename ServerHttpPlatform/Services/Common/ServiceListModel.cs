using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common
{
    public class ServiceListModel<TModel, TEntity> : IServiceListModel<TModel, TEntity>
    where TEntity: class
    {
        protected IMapper Mapper;
        protected IRepository<TEntity> Repository;

        public ServiceListModel(IMapper mapper, IRepository<TEntity> repository)
        {
            Mapper = mapper;
            Repository = repository;
        }


        public virtual async Task<List<TModel>> List()
        {
            List<TEntity> entities = await Repository.ListAsync();
            List<TModel> models = Mapper.Map<List<TModel>>(entities);
            return models;
        }

        public Task<List<TModel>> List(PagedSortListQuery query)
        {
            return List(CreateSpecification(query));
        }

        public Task<int> Count(PagedSortListQuery query)
        {
            return Count(CreateSpecification(query));
        }

        public virtual async Task<List<TModel>> List(ISpecification<TEntity> specification)
        {
            List<TEntity> entities = await Repository.ListAsync(specification);
            List<TModel> models = Mapper.Map<List<TModel>>(entities);
            return models;
        }

        public virtual Task<int> Count(ISpecification<TEntity> specification)
        {
            return Repository.CountAsync(specification);
        }

        protected virtual ISpecification<TEntity> CreateSpecification(PagedSortListQuery query)
        {
            return new PagedSpecification<TEntity>(query.Take, query.Skip, query.SortProp, query.SortOrder);
        }
    }
}
