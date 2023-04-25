using MedicalPrescriptionManagementSystemWebApi.Models;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public class EmailServiceDevelopment : IEmailService
    {
        private readonly EmailOptions _emailoptions;
        public EmailServiceDevelopment(IOptions<EmailOptions> emailOptions)
        {
            _emailoptions = emailOptions.Value;
        }
        public async Task SendEmailAsSystemAsync(string to, string subject, string body)
        {
            var emailClient = new SmtpClient(_emailoptions.Host)
            {
                Port = _emailoptions.Port,
                Credentials = new NetworkCredential(_emailoptions.FromEmail, _emailoptions.FromAppPassword),
                EnableSsl = _emailoptions.EnableSsl
            };

            var message = new MailMessage
            {
                From = new MailAddress(_emailoptions.FromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            message.To.Add(_emailoptions.ToEmail);
            await emailClient.SendMailAsync(message);
        }

        public async Task SendEmailAsync(string to, string from, string subject, string body)
        {
            var emailClient = new SmtpClient(_emailoptions.Host)
            {
                Port = _emailoptions.Port,
                Credentials = new NetworkCredential(_emailoptions.FromEmail, _emailoptions.FromAppPassword),
                EnableSsl = _emailoptions.EnableSsl
            };

            var message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            message.To.Add(_emailoptions.ToEmail);
            await emailClient.SendMailAsync(message);
        }
    }
}
