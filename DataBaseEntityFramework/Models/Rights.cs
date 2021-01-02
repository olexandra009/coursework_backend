namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Rights:DbModel<int>
    {
        #region Fields
        private bool _addingUser;
        private bool _editRights;
        private bool _createPetitions;
        private bool _votePetitions;
        private bool _createNewsAndEvents;
        private bool _moderateNewsAndEvents;
        private bool _createApplication;
        private bool _handlingApplication;

        #region Foriegn keys and principal entities 
        private User _user;
        private int _userId;
        #endregion

        #endregion

        #region Properties
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
        public int UserId
        {
            get => _userId;
            private set => _userId = value;
        }

        #endregion
/*
        #region Constructors

        public Rights(int id, bool addingUser, bool editRights, bool createPetitions, 
                        bool votePetitions, bool createNewsAndEvents, bool moderateNewsAndEvents, 
                        bool createApplication, bool handlingApplication, User user) :this()
        {
            Id = id;
            AddingUser = addingUser;
            EditRights = editRights;
            CreatePetitions = createPetitions;
            VotePetitions = votePetitions;
            CreateNewsAndEvents = createNewsAndEvents;
            ModerateNewsAndEvents = moderateNewsAndEvents;
            CreateApplication = createApplication;
            HandlingApplication = handlingApplication;
            User = user;
            UserId = user.Id;
        }

        public Rights()
        {
            
        }

        #endregion
*/
    }
}
