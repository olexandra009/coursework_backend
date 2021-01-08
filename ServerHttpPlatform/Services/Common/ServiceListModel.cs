using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;

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

        public Task<List<TModel>> List(int take, int skip = 0, string sortProp = null, string sortOder = null)
        {
            return List(CreateSpecification(take, skip, sortProp, sortOder));
        }

        public Task<int> Count(int take, int skip = 0, string sortProp = null, string sortOder = null)
        {
            return Count(CreateSpecification(take, skip, sortProp, sortOder));
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

        //todo implement sorted specification and page sorted and CreateSpecification method
        protected virtual ISpecification<TEntity> CreateSpecification(int take, int skip = 0, string sortProp = null, string sortOder = null)
        {
            throw new NotImplementedException();
        }
    }
}
