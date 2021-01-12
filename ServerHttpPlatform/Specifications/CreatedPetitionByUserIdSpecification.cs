using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    public class CreatedPetitionByUserIdSpecification : PagedSpecification<PetitionEntity>
    {
        public CreatedPetitionByUserIdSpecification(int userId, int take = 10, int skip = 0, string sortProp = null, string sortOrder = null) 
            : base(take, skip, sortProp, sortOrder)
        {
            Query.Where(p => p.AuthorId == userId);
        }
    }
}
