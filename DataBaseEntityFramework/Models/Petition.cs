using System;
using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    class Petition :IDbModel
    {
        #region Fields

        private Guid _id;
        private string _header;
        private string _text;
        private DateTime _starDate;
        private DateTime _finishDate;
        private User _author;
        private List<User> _votes;
        #endregion

        #region Properties
        public Guid Id
        {
            get => _id;
            private set => _id = value;
        }

        public string Header
        {
            get => _header;
            private set => _header = value;
        }

        public string Text
        {
            get => _text;
            private set => _text = value;
        }

        public DateTime StarDate
        {
            get => _starDate;
            private set => _starDate = value;
        }

        public DateTime FinishDate
        {
            get => _finishDate;
            private set => _finishDate = value;
        }

        public User Author
        {
            get => _author;
            private set => _author = value;
        }

        public List<User> Votes
        {
            get => _votes;
            private set => _votes = value;
        }
        #endregion
    }
}
