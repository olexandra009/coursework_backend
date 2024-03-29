﻿using System;
using System.Globalization;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using AutoMapper.Extensions.EnumMapping;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Mapping
{
    public class MappingProfile:Profile
    {
       
        public MappingProfile()
        { 
            CreateMap<Application, ApplicationDTO>().ForMember(dto=>dto.OpenDate, 
                                                    configExpression=>configExpression.MapFrom(model=>model.OpenDate.ToString("u")))
                                                    .ForMember(dto=>dto.CloseDate, 
                                                    configExpression=>configExpression.MapFrom(model=>(model.CloseDate==null)?null:((DateTime)model.CloseDate).ToString("u")))
                                                    .ForMember(dto => dto.Status, ex => ex.MapFrom(model => model.StatusModel));


            CreateMap<ApplicationDTO, Application>().ForMember(model => model.OpenDate,
                                                         configExpression => configExpression.MapFrom(dto => DateTime.Parse(dto.OpenDate, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)))
                                                    .ForMember(model => model.CloseDate,
                                                        configExpression => configExpression.MapFrom(dto =>
                                                            (dto.CloseDate == null) ? (DateTime?) null : (DateTime.Parse(dto.CloseDate, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal))))
                                                    .ForMember(model => model.StatusModel, ex => ex.MapFrom(dto => dto.Status));
            CreateMap<Application, ApplicationEntity>().ForMember(entity=>entity.Status, ex=>ex.MapFrom(model=>model.StatusModel));
            CreateMap<ApplicationEntity, Application>().ForMember(model => model.StatusModel, ex => ex.MapFrom(entity => entity.Status));
            ;

            CreateMap<StatusModel, StatusDTO>().ConvertUsingEnumMapping(opt => opt.MapValue(StatusModel.NullStatus, StatusDTO.NullStatus)
                                               .MapValue(StatusModel.Waiting, StatusDTO.Waiting).MapValue(StatusModel.Close, StatusDTO.Close).MapValue(StatusModel.InProcess, StatusDTO.InProcess));
            CreateMap<Status, StatusModel>().ConvertUsingEnumMapping(opt => opt.MapValue(Status.NullStatus, StatusModel.NullStatus)
                                               .MapValue(Status.Waiting, StatusModel.Waiting).MapValue(Status.Close, StatusModel.Close).MapValue(Status.InProcess, StatusModel.InProcess));
            CreateMap<StatusModel, Status > ().ConvertUsingEnumMapping(opt => opt.MapValue(StatusModel.NullStatus, Status.NullStatus)
                .MapValue(StatusModel.Waiting, Status.Waiting).MapValue(StatusModel.Close, Status.Close).MapValue(StatusModel.InProcess, Status.InProcess));

            CreateMap<StatusDTO, StatusModel>().ConvertUsingEnumMapping(opt => opt.MapValue(StatusDTO.NullStatus, StatusModel.NullStatus)
                .MapValue(StatusDTO.Waiting, StatusModel.Waiting).MapValue(StatusDTO.Close, StatusModel.Close).MapValue(StatusDTO.InProcess, StatusModel.InProcess));
            


            CreateMap<Event, EventDTO>().ForMember(dto=>dto.StartDate, confExp=>confExp.MapFrom(model=>model.StartDate.ToString("u")))
                .ForMember(dto => dto.EndDate, confExp => confExp.MapFrom(model => model.EndDate.ToString("u")));

            CreateMap<EventDTO, Event>().ForMember(model=>model.StartDate, confExp=>confExp.MapFrom(dto=>DateTime.Parse(dto.StartDate, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)))
                                         .ForMember(model => model.EndDate, confExp => confExp.MapFrom(dto => DateTime.Parse(dto.EndDate, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)));

            CreateMap<Event, EventEntity>();
            CreateMap<EventEntity, Event>();

            CreateMap<Multimedia, MultimediaDTO>();
            CreateMap<MultimediaDTO, Multimedia>();
            CreateMap<Multimedia, MultimediaEntity>();
            CreateMap<MultimediaEntity, Multimedia>();

            CreateMap<News, NewsDTO>().ForMember(dto=>dto.DateTimeCreation, confExp=>confExp.MapFrom(model=>model.DateTimeCreation.ToString("u")));
            CreateMap<NewsDTO, News>().ForMember(model => model.DateTimeCreation, confExp => confExp.MapFrom(dto => DateTime.Parse(dto.DateTimeCreation, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)));
            CreateMap<News, NewsEntity>();
            CreateMap<NewsEntity, News>();

            CreateMap<Organization, OrganizationDTO>();
            CreateMap<OrganizationDTO, Organization>();
            CreateMap<Organization, OrganizationEntity>();
            CreateMap<OrganizationEntity, Organization>();

            CreateMap<Petition, PetitionDTO>().ForMember(dto=>dto.StarDate, cEx=> cEx.MapFrom(model=>model.StarDate.ToString("u")))
                                              .ForMember(dto => dto.FinishDate, cEx => cEx.MapFrom(model => model.FinishDate.ToString("u")));
            CreateMap<PetitionDTO, Petition>().ForMember(model=>model.StarDate, cE=>cE.MapFrom(dto=> DateTime.Parse(dto.StarDate, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)))
                                              .ForMember(model => model.FinishDate, cE => cE.MapFrom(dto => DateTime.Parse(dto.FinishDate, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)));

            CreateMap<Petition, PetitionEntity>();
            CreateMap<PetitionEntity, Petition>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();


            CreateMap<User, UserEntity>();
            CreateMap<UserEntity, User>();

            CreateMap<Votes, VotesDTO>().ForMember(dto=>dto.DateTimeCreated, cEx=>cEx.MapFrom(model=>model.DateTimeCreated.ToString("u")));
            CreateMap<VotesDTO, Votes>().ForMember(model=>model.DateTimeCreated, cEx=>cEx.MapFrom(dto=> DateTime.Parse(dto.DateTimeCreated, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)));
            CreateMap<Votes, VotesEntity>();
            CreateMap<VotesEntity, Votes>();

            CreateMap<EmailConfirmEntity, EmailConfirmation>().ForMember(model=>model.UserId, configExpression=>configExpression.MapFrom(entity=>entity.UserKey));
            CreateMap<EmailConfirmation, EmailConfirmEntity>().ForMember(entity=>entity.UserKey, confExp=>confExp.MapFrom(model=>model.UserId));

        }
    }
}
