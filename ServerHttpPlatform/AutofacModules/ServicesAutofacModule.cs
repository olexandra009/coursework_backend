using Autofac;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.AutofacModules
{
    public class ServicesAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationService>()
                .As<IApplicationService>().InstancePerLifetimeScope();
            builder.RegisterType<EventService>()
                .As<IEventService>().InstancePerLifetimeScope();
            builder.RegisterType<MultimediaService>()
                .As<IMultimediaService>().InstancePerLifetimeScope();
            builder.RegisterType<NewsService>()
                .As<INewsService>().InstancePerLifetimeScope();
            builder.RegisterType<OrganizationService>()
                .As<IOrganizationService>().InstancePerLifetimeScope();
            builder.RegisterType<PetitionService>()
                .As<IPetitionService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>()
                .As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<VoteService>()
                .As<IVoteService>().InstancePerLifetimeScope();
            builder.RegisterType<EmailConfirmationService>()
                .As<IEmailConfirmationService>().InstancePerLifetimeScope();
        }
    }
}
