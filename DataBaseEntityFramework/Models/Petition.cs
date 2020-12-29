using System;
using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Petition :IDbModel
    {
        #region Fields

        private int _id;
        private string _header;
        private string _text;
        private DateTime _starDate;
        private DateTime _finishDate;

        #region Foriegn key and principal entity 
        private User _author;
        private int _authorId;
        #endregion

        #region Dependent entities
        private List<Votes> _votes;
        #endregion

        #endregion

        #region Properties
        public int Id
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
        public int AuthorId
        {
            get => _authorId;
            private set => _authorId = value;
        }

        public List<Votes> UserVotes
        {
            get => _votes;
            set => _votes = value;
        }
        #endregion

        #region Constructors

        public Petition(int id, string header, string text, 
                        DateTime starDate, DateTime finishDate, 
                        User author, int authorId) : this()
        {
            Id = id;
            Header = header;
            Text = text;
            StarDate = starDate;
            FinishDate = finishDate;
            Author = author;
            AuthorId = authorId;
            
        }

        public Petition()
        {

        }

        #endregion
    }
}
