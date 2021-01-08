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
            throw new NotImplementedException();
        }

        public virtual async Task<List<TModel>> List(ISpecification<TEntity> specification)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<int> Count(ISpecification<TEntity> specification)
        {
            throw new NotImplementedException();
        }
    }
}
