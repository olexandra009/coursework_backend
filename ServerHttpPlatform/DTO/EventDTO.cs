using System;
using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Edited { get; set; }
        public bool ShowAuthor { get; set; }
        public bool EmailNotification { get; set; }
        public UserDTO Author { get; set; }
        public int AuthorId { get; set; }
        public List<MultimediaDTO> Multimedias { get; set; }


    }
}
