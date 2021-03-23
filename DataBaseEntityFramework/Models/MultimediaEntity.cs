namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class MultimediaEntity:DbModel<int>
    {
   
        public string Url { get; set; }

        public EventEntity Event { get; set; }

        public NewsEntity News { get; set; }

        public ApplicationEntity Application { get; set; }

        public int? EventId { get; set; }

        public int? NewsId { get; set; }

        public int? ApplicationId { get; set; }

    }

}
