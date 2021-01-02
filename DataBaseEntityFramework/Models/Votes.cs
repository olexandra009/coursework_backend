namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Votes : DbModel<int>
    {
        #region Fields

        #region Foriegn keys and principal entities 
        private User _user;
        private int _userId;
        private Petition _petition;
        private int _petitionId;
        #endregion

        #endregion

        #region Properties
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

        public Petition Petition
        {
            get => _petition;
            private set => _petition = value;
        }

        public int PetitionId
        {
            get => _petitionId;
            private set => _petitionId = value;
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
