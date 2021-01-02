using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.Repositories
{
    public interface IReadOnlyRepository<TEntity> where TEntity:class
    {
        Task<bool> Exists(TEntity entity);
    }
}
