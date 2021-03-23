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
}
