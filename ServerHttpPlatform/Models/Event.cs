using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public class Event:IModel<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Edited { get; set; }
        public bool ShowAuthor { get; set; }
        public bool EmailNotification { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set; }
        public List<Multimedia> Multimedias { get; set; }


    }
}
