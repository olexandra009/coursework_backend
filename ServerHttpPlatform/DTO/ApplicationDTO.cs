using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO
{
    /// <summary>
    /// <value>Waiting = 1</value>
    /// <value>In progress = 2</value>
    /// <value>Close = 3</value>
    /// </summary>
    public enum StatusDTO
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

    public class ApplicationDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int? AnswerId { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public StatusDTO Status { get; set; }
        public string Result { get; set; }
        public string OpenDate { get; set; }
        public string? CloseDate { get; set; }
        public UserDTO Author { get; set; }
        public UserDTO Answerer { get; set; }
        public List<MultimediaDTO> Multimedias { get; set; }

    }
}
