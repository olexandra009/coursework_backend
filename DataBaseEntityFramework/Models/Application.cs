using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public enum Status
    {
        Waiting,   //application has been not read 
        InProcess, //application was read by answered
        Close      //answered close application and author can read result

    }
    public class Application : DbModel<int>
    {
        #region Fields

        private string _subject;
        private string _text;
        private Status _status; //TODO: change to enum
        private string _result;
        private DateTime _openDate;
        private DateTime? _closeDate;


        #region Foriegn keys and principal entities 
        private User _author;
        private int _authorId;
        private User _answerer;
        private int? _answerId;
        #endregion

        #region Dependent entity
        private List<Multimedia> _multimedias;
        #endregion

        #endregion

        #region Properties
        public int AuthorId
        {
            get => _authorId;
            private set => _authorId = value;
        }
        public int? AnswerId
        {
            get => _answerId;
            private set => _answerId = value;
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

        public Status Status
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

        public DateTime? CloseDate
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
        public List<Multimedia> Multimedias
        {
            get => _multimedias;
            set => _multimedias = value;
        }
        #endregion

        /*
        #region Constructors

        public Application(int id, string subject, string text, Status status, 
                           DateTime openDate, User author, int authorId,
                           User answerer = null, int? answerId = null, 
                           DateTime? closeDate = null, string result = null) :this()
        {
            Subject = subject;
            Text = text;
            Status = status;
            Result = result;
            OpenDate = openDate;
            CloseDate = closeDate;
            Author = author;
            AuthorId = authorId;
            Answerer = answerer;
            AnswerId = answerId;
        }

        public Application()
        {

        }

        #endregion
   */
    }

}
