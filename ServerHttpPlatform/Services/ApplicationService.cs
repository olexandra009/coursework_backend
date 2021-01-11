using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using Status = KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models.Status;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IApplicationService : IServiceCrudModel<Application, int, ApplicationEntity>
    {
        Task<Application> AddResult(Application application, string result);
        Task<Application> ChangeStatus(Application application, Status status);
       
    }
    //TODO Create application specification for get list : (by userId, status)
    public class ApplicationService : ServiceCrudModel<Application, int, ApplicationEntity>, IApplicationService
    {
        public ApplicationService(IMapper mapper, IRepository<ApplicationEntity> repository) : base(mapper, repository)
        {
        }
        
        //todo: think how can be protected updating by not admin user fields with result and status
        public Task<Application> AddResult(Application application, string result)
        {
            application.Result = result;
            return base.Update(application);
        }
        //TODO check how will convert statuses
        public Task<Application> ChangeStatus(Application application, Status status)
        {
            application.Status = status;
            return base.Update(application);
        }

    }
}
