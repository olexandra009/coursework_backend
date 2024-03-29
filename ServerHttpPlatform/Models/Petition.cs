﻿using System;
using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public class Petition : IModel<int>
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime FinishDate { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set;  }

        public List<Votes> UserVotes;

    }
}
