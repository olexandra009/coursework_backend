using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    public class ApplicationByAnswerId : PagedSpecification<ApplicationEntity>
    {
        public ApplicationByAnswerId(int take, int skip = 0, string sortProp = null, string sortOrder = null) : base(take, skip, sortProp, sortOrder)
        {
        }
    }
}
