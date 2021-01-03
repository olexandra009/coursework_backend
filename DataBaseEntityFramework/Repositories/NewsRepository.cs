using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{

    public interface INewsRepository
    {

    }

    public class NewsRepository : EfRepository<News>, INewsRepository
    {
       
        public NewsRepository(PlatformDbContext context) : base(context)
        {

        }

       
    }
}
