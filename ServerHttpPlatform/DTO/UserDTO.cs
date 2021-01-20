using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO
{
    public class UserDTO
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

        public OrganizationDTO UserOrganization { get; set; }
        public int? UserOrganizationId { get; set; }

    }
}
