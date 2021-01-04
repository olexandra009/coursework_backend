using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO
{
    public class OrganizationDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<UserDTO> Users { get; set; }
    }
}
