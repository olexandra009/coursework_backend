using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models
{
    public class EmailConfirmation:IModel<int>
    {
        public int Id { get; set; }
      //  public User User { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; }

    }
}
