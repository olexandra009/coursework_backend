﻿using System.Collections.Generic;
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

        //TODO: check if such update is working
        public override Task<Event> Update(Event model)
        {
            model.Edited = true;
            return base.Update(model);
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
            return await base.Create(model);
        }
    }
}
