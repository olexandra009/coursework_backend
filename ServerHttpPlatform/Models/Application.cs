using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public enum StatusModel
    {
        /// <summary> statusModel value for usage as a null, should not be added to entity in db </summary>
        NullStatus,
        /// <summary> application has been not read </summary>
        Waiting,
        /// <summary> application was read by answerer </summary>
        InProcess,
        /// <summary>answered close application and author can read result</summary>
        Close
    }
    public class Application : IModel<int>
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int? AnswerId { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public StatusModel StatusModel { get; set; }
        public string Result { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public User Author { get; set; }
        public User Answerer { get; set; }
        public List<Multimedia> Multimedias { get; set; }

    }
}
