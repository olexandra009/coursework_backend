
namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO
{
    public class MultimediaDTO 
    {
        public int Id { get; set; }
        public string Url { get; set; }
      //  public EventDTO Event { get; set; }
      //  public NewsDTO News { get; set; }
      //  public ApplicationDTO Application { get; set; }
        public bool IsImage { get; set; }
        public int? EventId { get; set; }
        public int? NewsId { get; set; }
        public int? ApplicationId { get; set; }
    }
}
