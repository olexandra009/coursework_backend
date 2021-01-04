using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public class Multimedia
    {
        public string Url;
        public Event Event;
        public News News;
        public Application Application;
        public int? EventId;
        public int? NewsId;
        public int? ApplicationId;
    }
}
