using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class User : DbModel<int>
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
        private Organization _userOrganization;
        private int? _userOrganizationId;
        #endregion

        #region Dependent entities
        //one to one
        private Rights _userRights; 
        //one to many
        private List<News> _createdNews; 
        private List<Event> _createdEvents;
        private List<Application> _createdApplications;
        private List<Application> _answerApplications;
        private List<Petition> _createdPetitions;
        //many to many
        private List<Votes> _votedPetitions;
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

        public Organization UserOrganization
        {
            get => _userOrganization;
            private set => _userOrganization = value;
        }
        public int? UserOrganizationId
        {
            get => _userOrganizationId;
            private set => _userOrganizationId = value;
        }

        public Rights UserRights
        {
            get => _userRights;
            set => _userRights = value;
        }
        public string Role
        {
            get => _role;
            set => _role = value;
        }

        public List<News> CreatedNews
        {
            get => _createdNews;
            set => _createdNews = value;
        }
        public bool EmailConfirm
        {
            get => _emailConfirm;
            private set => _emailConfirm = value;
        }


        public List<Event> CreatedEvents
        {
            get => _createdEvents;
            set => _createdEvents = value;
        }

        public List<Application> CreatedApplications
        {
            get => _createdApplications;
            set => _createdApplications = value;
        }

        public List<Application> AnswerApplications
        {
            get => _answerApplications;
            set => _answerApplications = value;
        }

        public List<Petition> CreatedPetitions
        {
            get => _createdPetitions;
            set => _createdPetitions = value;
        }

        public List<Votes> VotedPetitions
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
