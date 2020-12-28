using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Organization:IDbModel
    {
        #region Fields
        private Guid _id;
        private string _name;
        private string _address;
        private string _phoneNumber;
        private List<User> _users;
        #endregion

        #region Properties
        public Guid Id
        {
            get => _id;
            private set => _id = value;
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string Address
        {
            get => _address;
            private set => _address = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            private set => _phoneNumber = value;
        }

        public List<User> Users
        {
            get => _users;
            private set => _users = value;
        }

        #endregion

        #region Constructors

        public Organization(Guid id, string name,  List<User> users, 
                            string address=null, string phoneNumber=null) : this()
        {
            Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Users = users;
        }

        public Organization()
        {
            
        }
        #endregion
    }
}
