using System;
namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class MultimediaEvent
    {
        #region Fields

        private Multimedia _multimedia;
        private Guid _multimediaId;
        private Event _event;
        private Guid _eventId;

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

        public Event Event
        {
            get => _event;
            private set => _event = value;
        }

        public Guid EventId
        {
            get => _eventId;
            private set => _eventId = value;
        }

        #endregion

        #region Constructors

        public MultimediaEvent(Multimedia multimedia, Guid multimediaId, Event @event, Guid eventId)
        {
            Multimedia = multimedia;
            MultimediaId = multimediaId;
            Event = @event;
            EventId = eventId;
        }

        public MultimediaEvent()
        {
            
        }


        #endregion
    }
}
