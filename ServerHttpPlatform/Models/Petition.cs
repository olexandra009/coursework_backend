using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public class Petition : IModel<int>
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime FinishDate { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set;  }

        public List<Votes> UserVotes;

    }
}
