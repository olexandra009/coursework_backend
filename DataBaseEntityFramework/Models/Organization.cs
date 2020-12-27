﻿using System;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class Organization:IDbModel
    {
        #region Fields
        private Guid _id;
        private string _name;
        private string _address;
        private string _phoneNumber;
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

        #endregion
    }
}
