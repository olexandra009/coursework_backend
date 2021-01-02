using System;
using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class News : DbModel<int>
    {
        #region Fields

       
        private string _header;
        private string _text;
        private DateTime _dateTimeCreation;
        private bool _edited;
        private bool _showAuthor;

        #region Foriegn key and principal entity
        private User _author;
        private int _authorId;
        #endregion

        #region Dependent entity
        //one to many
        private List<Multimedia> _multimedias;
        #endregion

        #endregion

        #region Properties

       
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

        public DateTime DateTimeCreation
        {
            get => _dateTimeCreation;
            private set => _dateTimeCreation = value;
        }

        public bool Edited
        {
            get => _edited;
            private set => _edited = value;
        }
        public bool ShowAuthor
        {
            get => _showAuthor;
            private set => _showAuthor = value;
        }

        public User Author
        {
            get => _author;
            private set { _author = value; }
        }
        public int AuthorId
        {
            get => _authorId;
            private set { _authorId = value; }
        }
        public List<Multimedia> Multimedias
        {
            get => _multimedias;
            set => _multimedias = value;
        }
        #endregion
        /*
        #region Constructors

        public News(int id, string header, string text, DateTime dateTimeCreation, bool showAuthor, 
                    bool edited, User author, int authorId) : this()
        {
            Id = id;
            Header = header;
            Text = text;
            DateTimeCreation = dateTimeCreation;
            Edited = edited;
            Author = author;
            AuthorId = authorId;
            ShowAuthor = showAuthor;
        }

        public News() { }

        #endregion
        */
    }
}
