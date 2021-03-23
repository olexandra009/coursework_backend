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
        Task SendResetPasswordLetter(string email, string name, string url);
        Task SendAnswerApplicationLetter(string email, string name, string answerSubject, string answer);
        Task SendAnswerPetitionLetter(string email, string name, string petitionSubject, string answer);
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

        public Task SendAnswerPetitionLetter(string email, string name, string petitionSubject, string answer)
        {
            string subject = "Відповідь на петицію";
            string text = $"<p>Вітаємо, {name}</p> <p>Ви отримали відповідь на петицію: <b>" +petitionSubject+"</b></p>"+
                         $"<p>{answer}</p> З повагою,<br/>Адміністрація Community Platform";
            return SendLetters(new[] { email }, subject, text);
        }

        public Task SendConfirmLetter(string email, string name, string url)
        {

            string subject = "Підтвердження пошти";
            string text = $"<p>Вітаємо, {name}</p> <p>Ви отримали цей лист тому, що " +
                           "ваша адреса була використана при реєстрації на Community Platform.</p>" +
                           "</p> Бідь-ласка перейдіть за цим посиланням щоб підтвердити реєстрацію: " +
                          $"</p> <a href={url}>Підтвердити</a>" +
                           "<p>З повагою,<br/>Адміністрація Community Platform";
           return SendLetters(new[] {email}, subject, text);

        }

        public Task SendResetPasswordLetter(string email, string name, string url)
        {

            string subject = "Відновлення паролю";
            string text = $"<p>Вітаємо, {name}</p> <p>Ви отримали цей емейл тому, що щойно намагались" +
                          "скинути пароль від облікового запису Community Platform.</p>" +
                          "</p>Будь ласка, перейдіть за посиланням для підтвердження дії: " +
                          $"</p> <a href={url}>Скинути пароль</a>" +
                          "<p>З повагою,<br/>Адміністрація Community Platform";
            return SendLetters(new[] { email }, subject, text);

        }

        public Task SendEventNotificationLetter(string[] email, Event @event, string fromName = "")
        {
            string subject = $"Оповіщення про {@event.Name}";
            string text = $"<p>Вітаємо, </p> <p>Запрошуємо вас відвідати {@event.Name}.</p>" +
                          $"<p><b>Коли: {@event.StartDate.ToLocalTime()} - {@event.EndDate.ToLocalTime()}</b></p>" +
                          $"<p>{@event.Description}</p>" +
                          "<p>З повагою, <br/>";
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

        public Task SendAnswerApplicationLetter(string email, string name, string answerSubject, string answer)
        {
            string subject = "Відповідь на зверенення";
            string text = $"<p>Вітаємо, {name}</p> <p>Ви отримали відповідь на звернення: <b>" + answerSubject + "</b></p>" +
                          $"<p>{answer}</p> З повагою,<br/>Адміністрація Community Platform";
            return SendLetters(new[] { email }, subject, text);
        }
    }
}
