using Autofac;
using KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.Repositories;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.AutofacModules
{
    public class RepositoryReadOnlyAutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserReadOnlyRepository>()
                .As<IUserReadOnlyRepository>().InstancePerLifetimeScope();
        }
    }
}
