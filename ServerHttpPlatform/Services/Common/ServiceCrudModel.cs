using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common
{
    public class ServiceCrudModel<TModel, TKey, TEntity> : IServiceCrudModel<TModel, TKey>
    {
    }
}
