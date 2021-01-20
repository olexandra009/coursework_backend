using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface ISendEmailService
    {
        Task SendConfirmLetter(string email);
    }
    public class SendEmailService : ISendEmailService
    {
        public async Task SendConfirmLetter(string email)
        {
            Console.WriteLine("Send  letter to : " + email);
        }
    }
}
