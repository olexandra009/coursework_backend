using System;
using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO
{
    public class PetitionDTO
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public string StarDate { get; set; }
        public string FinishDate { get; set; }
        public UserDTO Author { get; set; }
        public int AuthorId { get; set;  }

        public int VotesNumber { get; set; }

        public List<VotesDTO> UserVotes { get; set; }

    }
}
