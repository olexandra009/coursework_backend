using System;
using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class News : IDbModel
    {
        #region Fields

        private Guid _id;
        private string _header;
        private string _text;
        private DateTime _dateTimeCreation;
        private bool _edited;
        private User _author;
        private Guid _authorId;
        private List<Multimedia> _multimedias;
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

        public User Author
        {
            get { return _author; }
            private set { _author = value; }
        }
        public Guid AuthorId
        {
            get { return _authorId; }
            private set { _authorId = value; }
        }
        public List<Multimedia> Multimedias
        {
            get => _multimedias;
            set => _multimedias = value;
        }
        #endregion

        #region Constructors

        public News(Guid id, string header, string text, DateTime dateTimeCreation, 
                    bool edited, User author, Guid authorId, List<Multimedia> multimedias) : this()
        {
            Id = id;
            Header = header;
            Text = text;
            DateTimeCreation = dateTimeCreation;
            Edited = edited;
            Author = author;
            AuthorId = authorId;
            Multimedias = multimedias;
        }

        public News() { }

        #endregion
    }
}
