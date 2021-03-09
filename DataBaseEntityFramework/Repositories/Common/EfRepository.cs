using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common
{
    public class EfRepository<TEntity> : IRepository<TEntity>
    where TEntity: DbModel<int>
    {
        protected readonly DbContext _dbContext;
        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            
            if (typeof(TEntity) == (typeof(UserEntity)))
            {
                int? orgId = (entity as UserEntity).UserOrganizationId;
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                if (orgId != (entity as UserEntity).UserOrganizationId)
                {
                    (entity as UserEntity).UserOrganizationId = orgId;
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();

                }
                return;
            }

            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            //foreach (var reference in _dbContext.Entry(entity).References)
            //    reference.IsModified = true;
            await _dbContext.SaveChangesAsync();
           
        }

        private bool IsDetached(TEntity entity)
        {
            var localEntity = _dbContext.Set<TEntity>().Local?.FirstOrDefault(x => Equals(x.Id, entity.Id));
            if (localEntity != null) // entity stored in local
                return false;

            return _dbContext.Entry(entity).State == EntityState.Detached;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

       
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var keys = new object[] {id};
            return await _dbContext.Set<TEntity>().FindAsync(keys);
        }

        public virtual async Task<TEntity> GetByIdAsync<TId>(TId id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }


        public virtual async Task<List<TEntity>> ListAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<List<TEntity>> ListAsync(ISpecification<TEntity> specification)
        {
            var specResult = ApplySpecification(specification);
            return await specResult.ToListAsync();
        }
        
        public virtual async Task<int> CountAsync(ISpecification<TEntity> specification)
        {
            var specResult = ApplySpecification(specification);
            return await specResult.CountAsync();

        }
        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            var evaluator = new SpecificationEvaluator<TEntity>();
            return evaluator.GetQuery(_dbContext.Set<TEntity>().AsQueryable(), spec);
        }

        #region Not Implemented (in IRepositoryBase) should be delete if would not be used
        /*
        public virtual Task<List<TResult>> ListAsync<TResult>(ISpecification<TEntity, TResult> specification)
        {
            throw new NotImplementedException();
        }
        public virtual Task<TEntity> GetBySpecAsync(ISpecification<TEntity> specification)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TResult> GetBySpecAsync<TResult>(ISpecification<TEntity, TResult> specification)
        {
            throw new NotImplementedException();
        }*/

        #endregion

    }
}
