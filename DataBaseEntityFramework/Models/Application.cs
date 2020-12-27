using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Application :IDbModel
    {
        #region Fields

        private Guid _id;
        private string _subject;
        private string _text;
        private string _status; //TODO: change to enum
        private string _result;
        private DateTime _openDate;
        private DateTime _closeDate;
        private User _author;
        private User _answerer;
        #endregion

        #region Properties
        public Guid Id
        {
            get => _id;
            private set => _id = value;
        }
        public string Subject
        {
            get => _subject;
            private set => _subject = value;
        }

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public string Status
        {
            get => _status;
            private set => _status = value;
        }

        public string Result
        {
            get => _result;
            private set => _result = value;
        }

        public DateTime OpenDate
        {
            get => _openDate;
            private set => _openDate = value;
        }

        public DateTime CloseDate
        {
            get => _closeDate;
            private set => _closeDate = value;
        }

        public User Author
        {
            get => _author;
            private set => _author = value;
        }

        public User Answerer
        {
            get => _answerer;
            private set => _answerer = value;
        }

        #endregion
    }
}
