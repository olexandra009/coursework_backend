using System;
using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO
{
    public class PetitionDTO
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime FinishDate { get; set; }
        public UserDTO Author { get; set; }
        public int AuthorId { get; set;  }

       // public List<VotesDTO> UserVotes;

    }
}
