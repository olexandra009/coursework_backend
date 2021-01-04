using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public interface IModel<Tkey>
    {
        Tkey Id { get; set; }
    }
}
