using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IRepository<T, in TKey> where T: DbModel<TKey>
    {
        Task<T> GetById(TKey id);
        Task<IReadOnlyList<T>> ListAll();
        Task<IReadOnlyList<T>> List(ISpecification<T> spec);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<int> Count(ISpecification<T> spec);
        Task<T> First(ISpecification<T> spec);
        Task<T> FirstOrDefault(ISpecification<T> spec);

    }
}
