using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IApplicationService : IServiceCrudModel<Application, int, ApplicationEntity>
    {
        Task<Application> AddResult(int applicationId, string result);
        Task<Application> ChangeStatus(int applicationId, StatusModel statusModel);
        Task<Application> ChangeTextOrSubject(int applicationId, Application applicationModel);


    }
    //TODO Create application specification for get list : (by userId, statusModel)
    public class ApplicationService : ServiceCrudModel<Application, int, ApplicationEntity>, IApplicationService
    {
        public ApplicationService(IMapper mapper, IApplicationRepository repository) : base(mapper, repository)
        {
        }
        
        //todo: think how can be protected updating by not admin user fields with result and statusModel
        public Task<Application> AddResult(int applicationId, string result)
        {
            var applic = Repository.GetByIdAsync(applicationId).Result;
            var application = Mapper.Map<Application>(applic);
            application.Result = result;
            return base.Update(application);
        }
        //TODO check how will convert statuses
        public Task<Application> ChangeStatus(int applicationId, StatusModel statusModel)
        {
            var app = Repository.GetByIdAsync(applicationId).Result;
            var application = Mapper.Map<Application>(app);
            application.StatusModel = statusModel;
            return base.Update(application);
        }

        public Task<Application> ChangeTextOrSubject(int applicationId, Application applicationModel)
        {
            var app = Repository.GetByIdAsync(applicationId).Result;
            var application = Mapper.Map<Application>(app);
            application.Subject = applicationModel.Subject;
            application.Text = applicationModel.Text;
            return base.Update(application);
        }

    }
}
