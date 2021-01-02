

using KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.PersonalInfoDataBase;

namespace KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.Repositories
{
    public interface IUserReadOnlyRepository
    {
    }
    public class UserReadOnlyRepository : RepositoryImplementation<User>, IUserReadOnlyRepository
    {
        public UserReadOnlyRepository(PersonalUsersInfoContext context) : base(context)
        {
            
        }
    }
}
