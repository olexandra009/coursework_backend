﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IApplicationService : IServiceCrudModel<Application, int, ApplicationEntity>
    {
        Task<Application> AddResult(int applicationId, string result);
        Task<Application> ChangeStatus(int applicationId, StatusModel statusModel);
        Task<Application> ChangeTextOrSubject(int applicationId, Application applicationModel);
    }
   
    public class ApplicationService : ServiceCrudModel<Application, int, ApplicationEntity>, IApplicationService
    {
        //todo change to use variable in settings 
        private static readonly TimeSpan DateToDelete = new TimeSpan(365,1, 0, 0);
        public ApplicationService(IMapper mapper, IApplicationRepository repository) : base(mapper, repository)
        {
        }

        #region Delete
        public override Task Delete(int id)
        {
            var application = Repository.GetByIdAsync(id).Result;
            DateTime? close = application.CloseDate ?? DateTime.Now;
            if (application.Status == Status.Close && DateTime.Now > (close + DateToDelete))
                return base.Delete(id);
            //todo change exception message
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

        //TODO Change multimedia 


        #endregion


    }
}
