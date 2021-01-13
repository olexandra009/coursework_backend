using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    /// <summary>
    /// Specification query for get list of multimedia for event
    /// </summary>
    public class MultimediaByEventIdSpecification : Specification<MultimediaEntity>
    {
        /// <summary>
        /// Creates specification query for get list of multimedia for event
        /// </summary>
        /// <param name="eventId"></param>
        public MultimediaByEventIdSpecification(int eventId)
        {
            Query.Where(m => m.EventId == eventId);
        }
    }
}
