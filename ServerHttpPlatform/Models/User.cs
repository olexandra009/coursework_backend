using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public class User: IModel<int>
    {
        public int Id { get; set; }
        public string FirstName {get; set;}
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool EmailConfirm { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Organization UserOrganization { get; set; }
        public int? UserOrganizationId { get; set; }
        public string UserOrganizationName { get; set; }
        public List<Petition> CreatedPetitions { get; set; }
        public List<Votes> VotedPetitions { get; set;}

    }
}
