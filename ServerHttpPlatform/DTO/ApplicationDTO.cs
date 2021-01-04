using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO
{
    public enum StatusDTO
    {
        Waiting,   //application has been not read 
        InProcess, //application was read by answered
        Close      //answered close application and author can read result

    }

    public class ApplicationDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int? AnswerId { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public StatusDTO Status { get; set; }
        public string Result { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public UserDTO Author { get; set; }
        public UserDTO Answerer { get; set; }
        public List<MultimediaDTO> Multimedias { get; set; }

    }
}
