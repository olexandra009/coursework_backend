using System;
using System.Collections.Generic;


namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class PetitionEntity :DbModel<int>
    {
        #region Properties

        public string Header { get; set; }

        public string Text { get; set; }

        public string Answer { get; set; }

        public DateTime StarDate { get; set; }

        public DateTime FinishDate { get; set; }

        public UserEntity Author { get; set; }

        public int AuthorId { get; set; }

        public List<VotesEntity> UserVotes { get; set; }

        #endregion
    }
}
