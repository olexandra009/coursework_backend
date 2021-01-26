using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface ISendEmailService
    {
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
