using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query for get list of multimedia for application
    /// </summary>
    public class MultimediaByApplicationIdSpecification:Specification<MultimediaEntity>
    {
        /// <summary>
        /// Creates specification query for get list of multimedia for application
        /// </summary>
        /// <param name="applicationId"></param>
        public MultimediaByApplicationIdSpecification(int applicationId)
        {
            Query.Where(m => m.ApplicationId == applicationId);
        }
    }
}
