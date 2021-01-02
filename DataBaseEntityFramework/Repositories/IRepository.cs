using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IRepository<TEntity> : IRepositoryBase<TEntity>
        where TEntity: class 
    {
       
    }
}
