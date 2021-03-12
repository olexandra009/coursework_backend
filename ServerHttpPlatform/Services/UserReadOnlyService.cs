using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IUserReadOnlyService
    {
        bool ExistsByIpnOrPassportNumber(string existsLine, bool isIpn, User user);
    }
    public class UserReadOnlyService:IUserReadOnlyService
    {
        protected IReadOnlyRepository ReadOnlyRepository;
        public UserReadOnlyService(IReadOnlyRepository userReadOnlyRepository)
        {
            ReadOnlyRepository = userReadOnlyRepository;
        }
        public bool ExistsByIpnOrPassportNumber(string existsLine, bool isIpn, User user)
        {
            if (isIpn)
                return ReadOnlyRepository.ExistsByIpn(existsLine, user.LastName, user.FirstName, user.SecondName);
            return ReadOnlyRepository.ExistsByPassport(existsLine, user.LastName, user.FirstName, user.SecondName); 
        }
    }
}
