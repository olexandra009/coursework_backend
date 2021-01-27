using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Mapping;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IApplicationService : IServiceCrudModel<Application, int, ApplicationEntity>
    {
        Task<Application> AddResult(int applicationId, string result);
        Task<Application> ChangeStatus(int applicationId, StatusModel statusModel);
        Task<Application> ChangeAnswerer(int applicationId, int answererId);
        Task<Application> ChangeTextOrSubject(int applicationId, Application applicationModel);
    }
    
    public class ApplicationService : ServiceCrudModel<Application, int, ApplicationEntity>, IApplicationService
    {
        protected IUserService UserService;
        protected IMultimediaService MultimediaService;
        private  readonly TimeSpan _dateToDelete;
        public ApplicationService(IMapper mapper, IUserService userService, IConfiguration configuration,
                                  IApplicationRepository repository, IMultimediaService multimedia) : base(mapper, repository)
        {
            UserService = userService;
            MultimediaService = multimedia;
            var confSection = configuration.GetSection("AppConfiguration");
            _dateToDelete = StringToTimeSpan.Convert(confSection["DeleteTimeSpan"]);

        }

        #region Get

        public override async Task<Application> Get(int id)
        {
            var model =  await base.Get(id);
            model.Author = await UserService.Get(model.AuthorId);
            if (model.AnswerId != null)
                model.Answerer = await UserService.Get((int)model.AnswerId);
            model.Multimedias = await MultimediaService.List(new MultimediaByApplicationIdSpecification(model.Id));
            return model;
        }

        #endregion
        #region Delete
        public override Task Delete(int id)
        {
            var application = Repository.GetByIdAsync(id).Result;
            DateTime? close = application.CloseDate ?? DateTime.Now;
            if (application.Status == Status.Close && DateTime.Now > (close + _dateToDelete))
                return base.Delete(id);
            //TODO change exception message
            throw new NotSupportedException("Try to delete not close application or application with ");
        }
        #endregion
        #region Edit
        public Task<Application> AddResult(int applicationId, string result)
        {
            var applic = Repository.GetByIdAsync(applicationId).Result;
            var application = Mapper.Map<Application>(applic);
            application.Result = result;
            return base.Update(application);
        }
        
        public Task<Application> ChangeStatus(int applicationId, StatusModel statusModel)
        {
            var app = Repository.GetByIdAsync(applicationId).Result;
            var application = Mapper.Map<Application>(app);
            application.StatusModel = statusModel;
            return base.Update(application);
        }

        public async Task<Application> ChangeAnswerer(int applicationId, int answererId)
        {
            var application = await Get(applicationId);
            if (application == null) return null;
            var answerer = await UserService.Get(answererId);
            if (answerer==null || !answerer.Role.Contains(Roles.ApplicationAdmin))
                return null;
            application.AnswerId = answererId;
            return application;
        }

        public Task<Application> ChangeTextOrSubject(int applicationId, Application applicationModel)
        {
            var app = Repository.GetByIdAsync(applicationId).Result;
            var application = Mapper.Map<Application>(app);
            application.Subject = applicationModel.Subject;
            application.Text = applicationModel.Text;
            return base.Update(application);
        }
        #endregion


    }
}
