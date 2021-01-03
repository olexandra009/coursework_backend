using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.Repositories;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform
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
