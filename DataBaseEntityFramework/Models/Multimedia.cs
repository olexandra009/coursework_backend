
using System;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    class Multimedia:IDbModel
    {
        #region Fields

        private Guid _id;
        private String _url;

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
        #endregion

        #region Constructors

        public Multimedia(Guid id, string url)
        {
            Id = id;
            Url = url;
        }

        public Multimedia()
        {
            
        }

        #endregion

    }
}
