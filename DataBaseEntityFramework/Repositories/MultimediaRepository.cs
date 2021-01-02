

using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories
{
    public interface IMultimediaRepository
    {
    }
    public class MultimediaRepository: EfRepository<Multimedia>, IMultimediaRepository
    {
        public MultimediaRepository(PlatformDbContext context):base(context)
        {
            
        }
    }
}
