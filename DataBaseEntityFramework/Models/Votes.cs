using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Votes : IDbModel
    {
        #region Fields
        private Guid _id;
        private Guid _userId;
        private Guid _petitionId;
        private User _user;
        private Petition _petition;
        #endregion

        #region Properties 
        public Guid Id
        {
            get => _id;
            private set => _id = value;
        }
        public Guid UserId
        {
            get => _userId;
            private set => _userId = value;
        }

        public Guid PetitionId
        {
            get => _petitionId;
            private set => _petitionId = value;
        }

        public User User
        {
            get => _user;
            private set => _user = value;
        }

        public Petition Petition
        {
            get => _petition;
            private set => _petition = value;
        }

        #endregion
    }
}
