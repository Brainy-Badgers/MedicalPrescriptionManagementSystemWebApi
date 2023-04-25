namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class EmailOptions
    {
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string FromAppPassword { get; set; }
        public string FromPassword { get; set; }
        public string ToEmail { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }
}
