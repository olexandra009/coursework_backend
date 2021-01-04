using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public class Organization : IModel<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<User> Users { get; set; }
    }
}
