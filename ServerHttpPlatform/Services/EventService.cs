using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IEventService : IServiceCrudModel<Event, int, EventEntity>
    {

    }
    public class EventService: ServiceCrudModel<Event, int, EventEntity>, IEventService
    {
        protected IMultimediaService MultimediaService;
        protected IUserService UserService;
        protected ISendEmailService MailService;
        public EventService(IMapper mapper, IMultimediaService multimediaService, 
                            IUserService userService, ISendEmailService sendMail, IEventRepository repository) : base(mapper, repository)
        {
            MultimediaService = multimediaService;
            UserService = userService;
            MailService = sendMail;
        }

        public override async Task<List<Event>> List(ISpecification<EventEntity> specification)
        {
            var models = await base.List(specification);
            foreach (var events in models)
            {
                events.Multimedias = await MultimediaService.List(new MultimediaByEventIdSpecification(events.Id));
                events.Author = await UserService.Get(events.AuthorId);
            }
            return models;
        }

        public override async Task<Event> Get(int id)
        {
            var model =  await base.Get(id);
            model.Multimedias = await MultimediaService.List(new MultimediaByEventIdSpecification(model.Id));
            model.Author = await UserService.Get(model.AuthorId);
            return model;
        }

      
        public override async Task<Event> Update(Event model)
        {
            model.Edited = true;
            var updated = await base.Update(model);
            var userModel = await UserService.Get(updated.AuthorId);
            updated.Author = userModel;
            return updated;
        }

        public override async Task<Event> Create(Event model)
        {
            if (model.EmailNotification)
            {
                var users = await UserService.List(new ConfirmedUserNotificationSpecification());
                List<string> emails = new List<string>();
                foreach (var user in users)
                {
                    emails.Add(user.Email);
                }

                var fromName = "";
                if (model.ShowAuthor)
                {
                    var author = (await UserService.Get(model.AuthorId));
                    fromName = author.FirstName +" "+ author.LastName;
                }

                await MailService.SendEventNotificationLetter(emails.ToArray(), model, fromName);
            }

            List<Multimedia> updatedList = new List<Multimedia>();
            foreach (var multimedia in model.Multimedias)
            {
                updatedList.Add(await MultimediaService.UploadMultimedia(multimedia));
            }
            model.Multimedias = updatedList;
            var modelCreated = await base.Create(model);
            var userModel = await UserService.Get(modelCreated.AuthorId);
            modelCreated.Author = userModel;
            return modelCreated;

        }
    }
}
