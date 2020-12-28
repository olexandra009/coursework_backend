using System;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Votes : IDbModel
    {
        #region Fields
        private Guid _id;
        private User _user;
        private Guid _userId;
        private Petition _petition;
        private Guid _petitionId;
        #endregion

        #region Properties
        public Guid Id
        {
            get => _id;
            private set => _id = value;
        }

        public User User
        {
            get => _user;
            private set => _user = value;
        }

        public Guid UserId
        {
            get => _userId;
            private set => _userId = value;
        }

        public Petition Petition
        {
            get => _petition;
            private set => _petition = value;
        }

        public Guid PetitionId
        {
            get => _petitionId;
            private set => _petitionId = value;
        }
        #endregion

        #region Constructors

        public Votes(Guid id, User user, Petition petition)
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
    }
}
