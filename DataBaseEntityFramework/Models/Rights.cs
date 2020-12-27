using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Rights:IDbModel
    {
        #region Fields
        private Guid _id;
        private bool _addingUser;
        private bool _editRights;
        private bool _createPetitions;
        private bool _votePetitions;
        private bool _createNewsAndEvents;
        private bool _moderateNewsAndEvents;
        private bool _createApplication;
        private bool _handlingApplication;
        private User _user;
        #endregion

        #region Properties
        public Guid Id
        {
            get => _id;
            private set => _id = value;
        }

        public bool AddingUser
        {
            get => _addingUser;
            private set => _addingUser = value;
        }

        public bool EditRights
        {
            get => _editRights;
            private set => _editRights = value;
        }

        public bool CreatePetitions
        {
            get => _createPetitions;
            private set => _createPetitions = value;
        }

        public bool VotePetitions
        {
            get => _votePetitions;
            private set => _votePetitions = value;
        }

        public bool CreateNewsAndEvents
        {
            get => _createNewsAndEvents;
            private set => _createNewsAndEvents = value;
        }

        public bool ModerateNewsAndEvents
        {
            get => _moderateNewsAndEvents;
            private set => _moderateNewsAndEvents = value;
        }

        public bool CreateApplication
        {
            get => _createApplication;
            private set => _createApplication = value;
        }

        public bool HandlingApplication
        {
            get => _handlingApplication;
            private set => _handlingApplication = value;
        }

        public User User
        {
            get => _user;
            private set => _user = value;
        }
        #endregion

    }
}
