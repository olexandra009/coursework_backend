
using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    public class ConfirmedUserNotificationSpecification: Specification<UserEntity>
    {
        public ConfirmedUserNotificationSpecification()
        {
            Query.Where(u => u.EmailConfirm);
        }
    }
}
