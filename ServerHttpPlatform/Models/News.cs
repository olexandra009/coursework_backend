using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public class News: IModel<int>
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public DateTime DateTimeCreation { get; set; }
        public bool Edited { get; set; }
        public bool ShowAuthor { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set; }
        public List<Multimedia> Multimedias { get; set; }
    }
}
