using System;
namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class MultimediaNews
    {
        #region Fileds

        private Multimedia _multimedia;
        private Guid _multimediaId;
        private News _news;
        private Guid _newsId;


        #endregion
        #region Properties

        public Multimedia Multimedia
        {
            get => _multimedia;
            private set => _multimedia = value;
        }

        public Guid MultimediaId
        {
            get => _multimediaId;
            private set => _multimediaId = value;
        }

        public News News
        {
            get => _news;
            private set => _news = value;
        }

        public Guid NewsId
        {
            get => _newsId;
            private set => _newsId = value;
        }

        #endregion

        #region Constructors

        public MultimediaNews(Multimedia multimedia, Guid multimediaId, News news, Guid newsId)
        {
            Multimedia = multimedia;
            MultimediaId = multimediaId;
            News = news;
            NewsId = newsId;
        }

        public MultimediaNews()
        {
            
        }
        

        #endregion
    }
}
