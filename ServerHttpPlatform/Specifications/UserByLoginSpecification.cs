using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    public class UserByLoginSpecification : Specification<UserEntity>
    {
        public UserByLoginSpecification(string login, string password)
        {
            Query.Where(u => u.Login == login && u.Password == password);
        }
    }
}
