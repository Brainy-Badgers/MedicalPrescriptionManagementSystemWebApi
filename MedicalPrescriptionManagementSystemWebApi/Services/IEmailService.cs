namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public interface IEmailService
    {
        Task SendEmailAsSystemAsync(string to, string subject, string body);
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
