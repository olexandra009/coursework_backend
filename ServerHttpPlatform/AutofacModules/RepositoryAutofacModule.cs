using Autofac;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.AutofacModules
{
    public class RepositoryUtcAutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationRepository>()
                .As<IApplicationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EventRepository>()
                .As<IEventRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MultimediaRepository>()
                .As<IMultimediaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NewsRepository>()
                .As<INewsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrganizationRepository>()
                .As<IOrganizationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PetitionRepository>()
                .As<IPetitionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<VotesRepository>()
                .As<IVotesRepository>().InstancePerLifetimeScope();

        }
    }
}
