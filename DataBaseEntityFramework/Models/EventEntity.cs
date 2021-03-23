using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class EventEntity :DbModel<int>
    {

        #region Properties
        public string Name { get;  set; }
        public string Description { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public bool Edited { get;  set; }
        public bool ShowAuthor { get;  set; }
        public bool EmailNotification { get;  set; }

        #region Foriegn key and principal entity

        public UserEntity Author { get;  set; }
        public int AuthorId { get;  set; }
        #endregion

        #region Dependent entity

        public List<MultimediaEntity> Multimedias { get; set; }
        #endregion

        #endregion
    }
}
