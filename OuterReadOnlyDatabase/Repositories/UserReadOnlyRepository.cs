using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.PersonalInfoDataBase;
using Microsoft.EntityFrameworkCore;

namespace KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.Repositories
{
    public class UserReadOnlyRepository : IReadOnlyRepository
    {
        protected readonly PersonalUsersInfoContext DbContext;

        public UserReadOnlyRepository(PersonalUsersInfoContext context)
        {
            DbContext = context;
        }



        public Task<bool> Exists(User entity)
        {
            //TODO create method that will get entity and specification maybe
            throw new NotImplementedException();
        }

        public async Task<User> Get(User entity)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByPassport(string pasNum, string lastName, string firstName, string secondName)
        {
            var firstOrDefault = DbContext.Users.FirstOrDefault(u => u.PasportNumber == pasNum);
            if (firstOrDefault == null) return false;
            if (firstOrDefault.FirstName != firstName) return false;
            if (firstOrDefault.LastName != lastName) return false;
            if (firstOrDefault.SecondName != secondName) return false;
            return true;
        }

        public bool ExistsByIpn(string ipn, string lastName, string firstName, string secondName)
        {
            var firstOrDefault = DbContext.Users.FirstOrDefault(u => u.IpnNumber == ipn);
            if (firstOrDefault == null) return false;
            if (firstOrDefault.FirstName != firstName) return false;
            if (firstOrDefault.LastName != lastName) return false;
            if (firstOrDefault.SecondName != secondName) return false;
            return true;
        }
    }
}
