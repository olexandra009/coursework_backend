using System;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class VotesEntity : DbModel<int>
    {
        public UserEntity User { get; set; }

        public int UserId { get;  set; }

        public PetitionEntity Petition { get;  set; }

        public int PetitionId { get;  set; }

        public DateTime DateTimeCreated { get;  set; }

    }
}
