using System;
using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO
{
    public class NewsDTO
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public string DateTimeCreation { get; set; }
        public bool Edited { get; set; }
        public bool ShowAuthor { get; set; }
        public UserDTO Author { get; set; }
        public int AuthorId { get; set; }
        public List<MultimediaDTO> Multimedias { get; set; }
    }
}
