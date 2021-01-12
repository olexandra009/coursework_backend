using System;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    public class FilterStatusPetitionSpecification : PagedSpecification<PetitionEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeStatus">allow values active, act, close, cls</param>
        /// <param name="votesStatus">allow values succ, successful, unsucc, unsuccessful</param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        ///<param name="sortProp">name of property to sort</param>
        /// <param name="sortOrder">order of sorting allow values: asc, desc</param>
        public FilterStatusPetitionSpecification(string timeStatus = null, string votesStatus = null, 
                                                int take = 10, int skip = 0, string sortProp = null, string sortOrder = null) : base(take, skip, sortProp, sortOrder)
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

            //todo change num to param
            switch (votesStatus.ToLower())
            {
                case "succ":
                case "successful":
                    Query.Where(p => p.UserVotes.Count >= 10);
                    break;
                case "unsucc":
                case "unsuccessful":
                    Query.Where(p => p.UserVotes.Count < 10);
                    break;
                default:
                    throw new ArgumentException();
            }


        }
    }
}
