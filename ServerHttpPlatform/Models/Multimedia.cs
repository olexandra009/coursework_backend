using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public class Multimedia : IModel<int>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Event Event { get; set; }
        public News News { get; set; }
        public Application Application { get; set; }
        public int? EventId { get; set; }
        public int? NewsId { get; set; }
        public int? ApplicationId { get; set; }
    }
}
