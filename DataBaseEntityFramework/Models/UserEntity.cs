using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class UserEntity : DbModel<int>
    {
        #region Fields

        private string _firstName;
        private string _secondName;
        private string _lastName;
        private string _phoneNumber;
        private string _email;

        #region Authentification and authorization information
        private string _login;
        private string _password;
        private string _role;
        private bool _emailConfirm;
        #endregion


        #region Foriegn key and principal entity 
        private OrganizationEntity _userOrganization;
        private int? _userOrganizationId;
        #endregion

        #region Dependent entities
        //one to many
        private List<NewsEntity> _createdNews; 
        private List<EventEntity> _createdEvents;
        private List<ApplicationEntity> _createdApplications;
        private List<ApplicationEntity> _answerApplications;
        private List<PetitionEntity> _createdPetitions;
        //many to many
        private List<VotesEntity> _votedPetitions;
        #endregion

        #endregion

        #region Properties
        public string FirstName
        {
            get => _firstName;
            private set => _firstName = value;
        }

        public string SecondName
        {
            get=>_secondName;
            private set => _secondName = value;
        }

        public string LastName
        {
            get => _lastName ;
            private set => _lastName = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            private set => _phoneNumber = value;
        }

        public string Email
        {
            get => _email;
            private set => _email = value;
        }

        public string Login
        {
            get => _login;
            private set => _login = value;
        }

        public string Password
        {
            get => _password;
            private set => _password = value;
        }

        public OrganizationEntity UserOrganization
        {
            get => _userOrganization;
            private set => _userOrganization = value;
        }
        public int? UserOrganizationId
        {
            get => _userOrganizationId;
            private set => _userOrganizationId = value;
        }

        public string Role
        {
            get => _role;
            set => _role = value;
        }

        public List<NewsEntity> CreatedNews
        {
            get => _createdNews;
            set => _createdNews = value;
        }
        public bool EmailConfirm
        {
            get => _emailConfirm;
            private set => _emailConfirm = value;
        }


        public List<EventEntity> CreatedEvents
        {
            get => _createdEvents;
            set => _createdEvents = value;
        }

        public List<ApplicationEntity> CreatedApplications
        {
            get => _createdApplications;
            set => _createdApplications = value;
        }

        public List<ApplicationEntity> AnswerApplications
        {
            get => _answerApplications;
            set => _answerApplications = value;
        }

        public List<PetitionEntity> CreatedPetitions
        {
            get => _createdPetitions;
            set => _createdPetitions = value;
        }

        public List<VotesEntity> VotedPetitions
        {
            get => _votedPetitions;
            set => _votedPetitions = value;
        }

        #endregion
/*
        #region Constructors

        public User(int guid, string firstName, string secondName, string lastName, 
                    string phoneNumber, string email, string login, string password, 
                    Organization userOrganization, int? userOrganizationId) :this()
        {
            Id = guid;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Login = login;
            Password = password;
            UserOrganization = userOrganization;
            UserOrganizationId = userOrganizationId;
           // UserRights = userRights;
            //CreatedNews = createdNews;
            //CreatedEvents = createdEvents;
            //CreatedApplications = createdApplications;
            //AnswerApplications = answerApplications;
            //CreatedPetitions = createdPetitions;
            //VotedPetitions = votedPetitions;
        }

        public User()
        {
            
        }

        #endregion
*/

    }
}
