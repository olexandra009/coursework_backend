using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Mapping;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using Microsoft.Extensions.Hosting.Internal;


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
        protected ISendEmailService EmailService;
        private  readonly TimeSpan _dateToDelete;
        public ApplicationService(IMapper mapper, IUserService userService, IConfiguration configuration, ISendEmailService emailService,
                                  IApplicationRepository repository, IMultimediaService multimedia) : base(mapper, repository)
        {
            UserService = userService;
            MultimediaService = multimedia;
            EmailService = emailService;
            var confSection = configuration.GetSection("AppConfiguration");
            _dateToDelete = StringToTimeSpan.Convert(confSection["DeleteTimeSpan"]);

        }


        #region Get

        public override async Task<List<Application>> List(ISpecification<ApplicationEntity> specification)
        {
            var models = await base.List(specification);
            foreach (var application in models)
            {
                application.Multimedias = await MultimediaService.List(new MultimediaByApplicationIdSpecification(application.Id));
                application.Author = await UserService.Get(application.AuthorId);
                if (application.AnswerId != null)
                    application.Answerer = await UserService.Get((int)application.AnswerId);

            }

            return models;
        }

        public override async Task<Application> Create(Application model)
        {
            List<Multimedia> updatedList = new List<Multimedia>();
            int i = 0;
            foreach (var multimedia in model.Multimedias)
            {
                updatedList.Add(await MultimediaService.UploadMultimedia(multimedia, 3, i));
                i++;
            }
            model.Multimedias = updatedList;
            var modelCreated = await base.Create(model);
            var userModel = await UserService.Get(modelCreated.AuthorId);
            modelCreated.Author = userModel;
            if (modelCreated.AnswerId != null)
            {
                var userModelAnswerer = await UserService.Get((int)modelCreated.AnswerId);
                modelCreated.Author = userModelAnswerer;
            }
            modelCreated.StatusModel = StatusModel.Waiting;
            return modelCreated;
        }

        public override async Task<Application> Get(int id)
        {
            var model =  await base.Get(id);
            if (model == null) return null;
            model.Author = await UserService.Get(model.AuthorId);
            if (model.AnswerId != null)
                model.Answerer = await UserService.Get((int)model.AnswerId);
            model.Multimedias = await MultimediaService.List(new MultimediaByApplicationIdSpecification(model.Id));
            return model;
        }

        #endregion
        #region Delete
        public override async Task Delete(int id)
        {
            var application = await Get(id);
            DateTime? close = application.CloseDate ?? DateTime.Now;
            if (application.StatusModel == StatusModel.Close && DateTime.Now > (close + _dateToDelete))
            {
                application.Multimedias.ForEach(image =>
                MultimediaService.DeleteMultimediaFromS3(image));
                await base.Delete(id);
            }
            //TODO change exception message
            throw new NotSupportedException("Try to delete not close application or application with ");
        }
        #endregion
        #region Edit
        public async Task<Application> AddResult(int applicationId, string result)
        {
            var applic = Repository.GetByIdAsync(applicationId).Result;
            var application = Mapper.Map<Application>(applic);
            application.Result = result;
            application.CloseDate = DateTime.UtcNow;
            application.StatusModel = StatusModel.Close;
            var user = await UserService.Get(application.AuthorId);
            if(user==null) return await base.Update(application);
            await EmailService.SendAnswerApplicationLetter(user.Email, user.FirstName, application.Subject,
                application.Result);
            return await base.Update(application);
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
            application.Author = null;
            application.Answerer = null;
            var answerer = await UserService.Get(answererId);
            if (answerer==null || !answerer.Role.Contains(Roles.ApplicationAdmin))
                return null;
            application.AnswerId = answererId;
            application.StatusModel = StatusModel.InProcess;
            return await base.Update(application);
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
