﻿using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public enum Status
    {
        /// <summary> status value for usage as a null, should not be added to entity in db </summary>
        NullStatus,
        /// <summary> application has been not read </summary>
        Waiting,
        /// <summary> application was read by answerer </summary>
        InProcess,
        /// <summary>answered close application and author can read result</summary>
        Close    

    }
    public class ApplicationEntity : DbModel<int>
    {
        #region Properties

        #region Foriegn keys and principal entities

        public int AuthorId { get; set; }
        public int? AnswerId { get; set; }
        public UserEntity Author { get; set; }
        public UserEntity Answerer { get; set; }
        #endregion

        public string Subject { get; set; }
        public string Text { get; set; }
        public Status Status { get; set; }
        public string Result { get; set; }
        public DateTime OpenDate { get;  set; }
        public DateTime? CloseDate { get; set; }

        #region Dependent entity
        public List<MultimediaEntity> Multimedias { get; set; }
        #endregion

        #endregion
    }

}
