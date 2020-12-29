using System;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class MultimediaApplication
    {
        #region Fileds

        private Multimedia _multimedia;
        private Guid _multimediaId;
        private Application _application;
        private Guid _applicationId;


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

        public Application Application
        {
            get => _application;
            private set => _application = value;
        }

        public Guid ApplicationId
        {
            get => _applicationId;
            private set => _applicationId = value;
        }

        #endregion

        #region Constructors

        public MultimediaApplication(Multimedia multimedia, Guid multimediaId, 
                                    Application application, Guid applicationId) :this()
        {
            Multimedia = multimedia;
            MultimediaId = multimediaId;
            Application = application;
            ApplicationId = applicationId;
        }

        public MultimediaApplication()
        {
            
        }
        #endregion
    }
}
