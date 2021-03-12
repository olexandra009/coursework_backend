using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.PersonalInfoDataBase;

namespace KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.Repositories
{
    public interface IReadOnlyRepository
    {
        Task<bool> Exists(User entity);
        Task<User> Get(User entity); 
        bool ExistsByPassport(string pasNum, string lastName, string firstName, string secondName);
        bool ExistsByIpn(string ipn, string lastName, string firstName, string secondName);
    }
}
