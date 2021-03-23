using System;
using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class NewsEntity : DbModel<int>
    {
      
        public string Header { get;  set; }

        public string Text { get;  set; }

        public DateTime DateTimeCreation { get;  set; }

        public bool Edited { get;  set; }

        public bool ShowAuthor { get;  set; }

        public UserEntity Author { get;  set; }

        public int AuthorId { get;  set; }

        public List<MultimediaEntity> Multimedias { get; set; }

    }
}
