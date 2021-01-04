using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class EventEntity :DbModel<int>
    {

        #region Fields
      
        private string _name;
        private string _description;
        private DateTime _startDate;
        private DateTime _endDate;
        private bool _edited;
        private bool _showAuthor;
        private bool _emailNotification;

        #region Foriegn key and principal entity
        private UserEntity _author;
        private int _authorId;
        #endregion

        #region Dependent entity
        private List<MultimediaEntity> _multimedias;
        #endregion


        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            private set => _name = value;
        }
        public string Description
        {
            get => _description;
            private set => _description = value;
        }
        public DateTime StartDate
        {
            get => _startDate;
            private set => _startDate = value;
        }
        public DateTime EndDate
        {
            get => _endDate;
            private set => _endDate = value;
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
        public bool EmailNotification
        {
            get => _emailNotification;
            private set => _emailNotification = value;
        }

        public UserEntity Author
        {
            get => _author;
            private set => _author = value;
        }
        public int AuthorId
        {
            get => _authorId;
            private set => _authorId = value;
        }
         public List<MultimediaEntity> Multimedias
        {
            get => _multimedias;
            set => _multimedias = value;
        }

        #endregion
/*
        #region Constructors

        public Event(int id, string name, string description, 
                     DateTime startDate, DateTime endDate, bool edited, 
                     bool emailNotification, User author, int authorId, bool showAuthor) : this() 
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Edited = edited;
            ShowAuthor = showAuthor;
            EmailNotification = emailNotification;
            Author = author;
            AuthorId = authorId;
        }
        public Event() { }
        #endregion
*/
    }
}
