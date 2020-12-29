using System;
namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Multimedia:IDbModel
    {
        #region Fields

        private Guid _id;
        private String _url;
        private Event _event;
        private News _news;
        private Application _application;
        private Guid? _eventId;
        private Guid? _newsId;
        private Guid? _applicationId;
      

        #endregion

        #region Properties

        public Guid Id
        {
            get => _id;
            private set => _id = value;
        }
        public String Url
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

        public Guid? EventId
        {
            get => _eventId;
            private set => _eventId = value;
        }

        public Guid? NewsId
        {
            get => _newsId;
            private set => _newsId = value;
        }

        public Guid? ApplicationId
        {
            get => _applicationId;
            private set => _applicationId = value;
        }

        #endregion

        #region Constructors

        public Multimedia(Guid id, string url, Event @event, News news, 
                        Application application, Guid eventId, Guid newsId, 
                        Guid applicationId) : this()
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
