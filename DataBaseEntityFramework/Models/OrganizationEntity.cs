using System;
using System.Collections.Generic;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
    public class OrganizationEntity:DbModel<int>
    {
        #region Fields

        #region Dependent Entity

        #endregion

        #endregion

        #region Properties
       
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public List<UserEntity> Users { get; set; }

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
