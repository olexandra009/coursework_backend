using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.Repositories
{
    public class RepositoryImplementation <TEntity>: IReadOnlyRepository<TEntity> 
        where TEntity:class
    {
        protected readonly DbContext DbContext;

        public RepositoryImplementation(DbContext context)
        {
            DbContext = context;
        }

        public Task<bool> Exists(TEntity entity)
        {
            //TODO create method that will get entity and specification maybe
            //     and return true if there are items with it (get by alternative key)
            throw new NotImplementedException();
        }
    }
}
