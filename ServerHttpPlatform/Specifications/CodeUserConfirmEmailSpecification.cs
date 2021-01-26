using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    public class CodeUserConfirmEmailSpecification : Specification<EmailConfirmEntity>
    {
        public CodeUserConfirmEmailSpecification(int userId)
        {
            Query.Where(e => e.UserKey == userId);
        }
    }

}
