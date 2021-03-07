

using System.ComponentModel.DataAnnotations;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO
{
    public class VotesDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public int UserId { get; set; }
       // public PetitionDTO Petition { get; set; }
        public int PetitionId { get; set; }
        public string DateTimeCreated { get; set; }

    }
}
