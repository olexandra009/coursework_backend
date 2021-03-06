using System;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class VotesEntity : DbModel<int>
    {
        #region Fields

        private DateTime _dateTimeCreated;

        #region Foriegn keys and principal entities 
        private UserEntity _user;
        private int _userId;
        private PetitionEntity _petition;
        private int _petitionId;
        #endregion

        #endregion

        #region Properties
        public UserEntity User
        {
            get => _user;
            private set => _user = value;
        }

        public int UserId
        {
            get => _userId;
            private set => _userId = value;
        }

        public PetitionEntity Petition
        {
            get => _petition;
            private set => _petition = value;
        }

        public int PetitionId
        {
            get => _petitionId;
            private set => _petitionId = value;
        }

        public DateTime DateTimeCreated
        {
            get => _dateTimeCreated;
            private set => _dateTimeCreated = value;
        }
        #endregion
/*
        #region Constructors

        public Votes(int id, User user, Petition petition)
        {
            Id = id;
            User = user;
            UserId = user.Id;
            Petition = petition;
            PetitionId = petition.Id;
        }

        public Votes()
        {
            
        }
        

        #endregion
*/
    }
}
