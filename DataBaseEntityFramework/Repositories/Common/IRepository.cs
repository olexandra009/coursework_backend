using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;

using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

        Task SaveChangesAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByIdAsync<TId>(TId id);

        Task<List<TEntity>> ListAsync();

        Task<List<TEntity>> ListAsync(ISpecification<TEntity> specification);

        Task<int> CountAsync(ISpecification<TEntity> specification);
    }
}
