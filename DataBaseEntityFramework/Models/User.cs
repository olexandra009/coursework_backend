using System;
namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class User : IDbModel
    {
        #region Fields
        private Guid _guid;
        private string _firstName;
        private string _secondName;
        private string _lastName;
        private string _phoneNumber;
        private string _email;
        private string _login;
        private string _password;
        #endregion

        #region Properties
        public Guid Id
        {
            get => _guid;
            private set => _guid = value;
        }

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

        #endregion



    }
}
