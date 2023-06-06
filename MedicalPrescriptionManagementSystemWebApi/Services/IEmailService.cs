using System.Net.Mail;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public interface IEmailService
    {
        Task SendEmailAsSystemAsync(string to, string subject, string body);
        Task SendEmailAsync(string to, string from, string subject, string body);
        Task SendEmailAsSystemAsync(string to, string subject, string body, List<Attachment> attachments);
        Task SendQREmailAsSystemAsync(string to, string subject, string body,string qrLink);

    }
}
