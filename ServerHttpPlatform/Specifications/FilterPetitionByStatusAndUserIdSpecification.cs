using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    public class FilterPetitionByStatusAndUserIdSpecification : PagedSpecification<PetitionEntity>
    {
        public FilterPetitionByStatusAndUserIdSpecification(int number, int userId, PagedSortListQuery query, string timeStatus = null, string votesStatus = null)
            : base(query.Take, query.Skip, query.SortProp, query.SortOrder)
        {
            if (timeStatus != null)
            {
                switch (timeStatus.ToLower())
                {
                    case "active":
                    case "act":
                        Query.Where(p => p.FinishDate > DateTime.Now);
                        break;
                    case "close":
                    case "cls":
                        Query.Where(p => p.FinishDate < DateTime.Now);
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            if (votesStatus == null) return;

            switch (votesStatus.ToLower())
            {
                case "succ":
                case "successful":
                    Query.Where(p => p.UserVotes.Count >= number);
                    break;
                case "unsucc":
                case "unsuccessful":
                    Query.Where(p => p.UserVotes.Count < number);
                    break;
                default:
                    throw new ArgumentException();
            }

            Query.Where(p => p.AuthorId == userId);

        }
    }
}
