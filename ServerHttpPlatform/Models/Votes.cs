using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public class Votes : IModel<int>
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Petition Petition { get; set; }
        public int PetitionId { get; set; }
        public DateTime DateTimeCreated { get; set; }

    }
}
