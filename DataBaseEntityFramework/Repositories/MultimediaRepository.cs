

using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IMultimediaRepository
    {
    }
    public class MultimediaRepository: EfRepository<MultimediaEntity>, IMultimediaRepository
    {
        public MultimediaRepository(PlatformDbContext context):base(context)
        {
            
        }
    }
}
