﻿using System;
using System.Collections.Generic;

#nullable disable

namespace KMA.Coursework.CommunicationPlatform.OuterReadOnlyDatabase.PersonalInfoDataBase
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string PasportNumber { get; set; }
        public string IpnNumber { get; set; }
    }
}
