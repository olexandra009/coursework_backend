using System;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification for getting list of petition filtered by finish date and votes count
    /// </summary>
    public class FilterStatusPetitionSpecification : PagedSpecification<PetitionEntity>
    {
        /// <summary>
        /// Create specification for getting list of petition filtered by finish date and votes count
        /// </summary>
        /// <param name="number">a number of votes for successful petition</param>
        /// <param name="query"></param>
        /// <param name="timeStatus">allow values active, act, close, cls</param>
        /// <param name="votesStatus">allow values succ, successful, unsucc, unsuccessful</param>
        public FilterStatusPetitionSpecification(int number, PagedSortListQuery query, string timeStatus = null, string votesStatus = null) 
                                                : base(query.Take, query.Skip, query.SortProp, query.SortOrder)
        {
            if (timeStatus != null)
            {
                switch (timeStatus.ToLower())
                {
                    case "active":
                    case "act":
                        Query.Where(p => p.FinishDate < DateTime.Now);
                        break;
                    case "close":
                    case "cls":
                        Query.Where(p => p.FinishDate > DateTime.Now);
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            if(votesStatus==null) return;

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


        }
    }
}
