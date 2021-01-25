using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<Application, ApplicationDTO>();
            CreateMap<ApplicationDTO, Application>();
            CreateMap<Application, ApplicationEntity>();
            CreateMap<ApplicationEntity, Application>();

            CreateMap<StatusModel, StatusDTO>();
            CreateMap<Status, StatusModel>();
            CreateMap<StatusModel, Status > ();
            CreateMap<StatusDTO, StatusModel>();


            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();
            CreateMap<Event, EventEntity>();
            CreateMap<EventEntity, Event>();

            CreateMap<Multimedia, MultimediaDTO>();
            CreateMap<MultimediaDTO, Multimedia>();
            CreateMap<Multimedia, MultimediaEntity>();
            CreateMap<MultimediaEntity, Multimedia>();

            CreateMap<News, NewsDTO>();
            CreateMap<NewsDTO, News>();
            CreateMap<News, NewsEntity>();
            CreateMap<NewsEntity, News>();

            CreateMap<Organization, OrganizationDTO>();
            CreateMap<OrganizationDTO, Organization>();
            CreateMap<Organization, OrganizationEntity>();
            CreateMap<OrganizationEntity, Organization>();

            CreateMap<Petition, PetitionDTO>();
            CreateMap<PetitionDTO, Petition>();
            CreateMap<Petition, PetitionEntity>();
            CreateMap<PetitionEntity, Petition>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserEntity>();
            CreateMap<UserEntity, User>();

            CreateMap<Votes, VotesDTO>();
            CreateMap<VotesDTO, Votes>();
            CreateMap<Votes, VotesEntity>();
            CreateMap<VotesEntity, Votes>();

            CreateMap<EmailConfirmEntity, EmailConfirmation>();
            CreateMap<EmailConfirmation, EmailConfirmEntity>();

        }
    }
}
