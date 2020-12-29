using System;
namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Multimedia:IDbModel
    {
        #region Fields

        private int _id;
        private string _url;
        private Event _event;
        private News _news;
        private Application _application;
        private int? _eventId;
        private int? _newsId;
        private int? _applicationId;
      

        #endregion

        #region Properties

        public int Id
        {
            get => _id;
            private set => _id = value;
        }
        public string Url
        {
            get => _url;
            private set => _url = value;
        }

        public Event Event
        {
            get => _event;
            private set => _event = value;
        }

        public News News
        {
            get => _news;
            private set => _news = value;
        }

        public Application Application
        {
            get => _application;
            private set => _application = value;
        }

        public int? EventId
        {
            get => _eventId;
            private set => _eventId = value;
        }

        public int? NewsId
        {
            get => _newsId;
            private set => _newsId = value;
        }

        public int? ApplicationId
        {
            get => _applicationId;
            private set => _applicationId = value;
        }

        #endregion

        #region Constructors

        public Multimedia(int id, string url, Event @event, News news, 
                        Application application, int? eventId, int? newsId, 
                        int? applicationId) : this()
        {
            Id = id;
            Url = url;
            Event = @event;
            News = news;
            Application = application;
            EventId = eventId;
            NewsId = newsId;
            ApplicationId = applicationId;
        }

        public Multimedia()
        {
            
        }

        #endregion

    }
}
