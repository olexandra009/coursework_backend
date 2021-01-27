using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using Microsoft.Extensions.Configuration;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface ISendEmailService
    {

        Task SendEventNotificationLetter(string[] email, Event @event, string fromName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">Emails to send</param>
        /// <param name="subject"></param>
        /// <param name="text"></param>
        /// <param name="fromName">Name of sender</param>
        /// <returns></returns>
        Task SendLetters(string[] email, string subject, string text, string fromName);

        Task SendConfirmLetter(string email, string name, string url);
    }
    public class SendEmailService : ISendEmailService
    {
        private readonly IConfigurationSection _configuration;
        public SendEmailService(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("EmailConnection");
        }
        public Task SendConfirmLetter(string email, string name, string url)
        {

            string subject = "Email Confirmation";
            string text = $"<p>Hi, {name}</p> <p>You have received this email because your email " +
                           "address was used for registration in Platform Utc.</p>" +
                           "</p> Please follow this link to confirm your decision: " +
                          $"</p> <a href={url}>Confirm email</a>" +
                           "<p> Yours truly,<br/>Platform Utc Administration";
           return SendLetters(new[] {email}, subject, text);

        }

        public Task SendEventNotificationLetter(string[] email, Event @event, string fromName = "")
        {
            string subject = $"Notification about {@event.Name}";
            string text = $"<p>Hi, </p> <p>We invite you to attend {@event.Name}.</p>" +
                          $"<p><b>When: {@event.StartDate.ToLocalTime()} - {@event.EndDate.ToLocalTime()}</b></p>" +
                          $"<p>{@event.Description}</p>" +
                          "<p>Yours truly, <br/>";
            if (!string.IsNullOrEmpty(fromName))
                text += fromName + "</p>";
            return SendLetters(email, subject, text, fromName);

        }

        public async Task SendLetters(string[] email, string subject, string text, string fromName="")
        {
            string senderEmail = _configuration["Email"];
            string senderPassword = _configuration["Password"];
            string smtpServer = _configuration["Smtp"];
            int port = Convert.ToInt32(_configuration["Port"]);
            bool ssl = Convert.ToBoolean(_configuration["SSL"]);
            if (string.IsNullOrEmpty(fromName))
                fromName = _configuration["DefaultName"];
            var message = new MailMessage
            {
                Body = text,
                Subject = subject,
                From = new MailAddress(senderEmail, fromName),
                IsBodyHtml = true
            };
           
            foreach (var e in email)
            {
                message.To.Add(e);
            }
            SmtpClient smtpClient = new SmtpClient() { Host = smtpServer, Port = port, EnableSsl = ssl };
            NetworkCredential networkCredential = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.Credentials = networkCredential;
            await Task.Run(() => smtpClient.Send(message));
            Console.WriteLine("Send  letter to : " + email);
        }

    }
}
