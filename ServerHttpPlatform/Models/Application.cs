using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public enum Status
    {
        Waiting,   //application has been not read 
        InProcess, //application was read by answered
        Close      //answered close application and author can read result

    }
    public class Application
    {
        public int AuthorId { get; set; }
        public int? AnswerId { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public Status Status { get; set; }
        public string Result { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public User Author { get; set; }
        public User Answerer { get; set; }
        public List<Multimedia> Multimedias { get; set; }

    }
}
