﻿using System;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Event :IDbModel
    {

        #region Fields
        private Guid _id;
        private string _name;
        private string _description;
        private DateTime _startDate;
        private DateTime _endDate;
        private bool _edited;
        private bool _emailNotification;
        private User _author;
        private Guid _authorId;
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
        public bool EmailNotification
        {
            get => _emailNotification;
            private set => _emailNotification = value;
        }

        public User Author
        {
            get => _author;
            private set => _author = value;
        }
        public Guid AuthorId
        {
            get => _authorId;
            private set => _authorId = value;
        }
        public Guid Id
        {
            get =>  _id; 
            set => _id = value; 
        }

        #endregion

        #region Constructors

        public Event(Guid id, string name, string description, 
                     DateTime startDate, DateTime endDate, bool edited, 
                     bool emailNotification, User author, Guid authorId) : this() 
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Edited = edited;
            EmailNotification = emailNotification;
            Author = author;
            AuthorId = authorId;
        }
        public Event() { }
        #endregion
    }
}
