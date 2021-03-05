﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models
{
   public class EmailConfirmEntity:DbModel<int>
    {
        public UserEntity User { get; set; }
        public int UserKey { get; set; }
        public string Code { get; set; }
    }
}
