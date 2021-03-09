using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    public class UserByEmailSpecification : Specification<UserEntity>
    {
        public UserByEmailSpecification(string email)
        {
            Query.Where(u => u.Email == email);
        }
    }

}
