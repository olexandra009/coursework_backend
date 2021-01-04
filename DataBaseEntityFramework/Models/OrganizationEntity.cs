using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class OrganizationEntity:DbModel<int>
    {
        #region Fields
       
        private string _name;
        private string _address;
        private string _phoneNumber;

        #region Dependent Entity
        private List<UserEntity> _users;
        #endregion

        #endregion

        #region Properties
       
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

        public List<UserEntity> Users
        {
            get => _users;
            set => _users = value;
        }

        #endregion
/*
        #region Constructors

        public Organization(int id, string name, string address=null, string phoneNumber=null) : this()
        {
            Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public Organization()
        {
            
        }
        #endregion
*/
    }
}
