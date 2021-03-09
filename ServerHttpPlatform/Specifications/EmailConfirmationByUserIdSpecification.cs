using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    public class EmailConfirmationByUserIdSpecification: Specification<EmailConfirmEntity>
    {
        public EmailConfirmationByUserIdSpecification(int userId)
        {
            Query.Where(e => e.UserKey == userId);
        }
    }
}
