namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Multimedia:DbModel<int>
    {
        #region Fields

       
        private string _url;

        #region Foriegn keys and principal entities 
        private Event _event;
        private News _news;
        private Application _application;
        private int? _eventId;
        private int? _newsId;
        private int? _applicationId;
        #endregion

        #endregion

        #region Properties
        public string Url
        {
            get => _url;
            set => _url = value;
        }

        public Event Event
        {
            get => _event;
            set => _event = value;
        }

        public News News
        {
            get => _news;
            set => _news = value;
        }

        public Application Application
        {
            get => _application;
            set => _application = value;
        }

        public int? EventId
        {
            get => _eventId;
            set => _eventId = value;
        }

        public int? NewsId
        {
            get => _newsId;
            set => _newsId = value;
        }

        public int? ApplicationId
        {
            get => _applicationId;
            set => _applicationId = value;
        }

        #endregion
        /*
                #region Constructors

                public Multimedia(int id, string url) : this()
                {
                    Id = id;
                    Url = url;
                }

                public Multimedia()
                {

                }

                #endregion
        */
    }

}
