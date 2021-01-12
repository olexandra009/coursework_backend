using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.VotesSpecification
{
    public class VotesByUserWithIdSpecification : Specification<VotesEntity>
    {
        public VotesByUserWithIdSpecification(int userId)
        {
            Query.Where(v => v.UserId == userId).Include(v => v.Petition);

        }
    }
}
