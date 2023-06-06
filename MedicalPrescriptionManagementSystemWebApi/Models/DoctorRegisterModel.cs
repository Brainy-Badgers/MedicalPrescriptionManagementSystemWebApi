namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class DoctorRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Specialization { get; set; } = "Default Specialization";
        public string HospitalName { get; set; } = "Default Hospital name";
        public string? ContactNo { get; set; }
        public string? ConfirmationFileUrl { get; set; }
    }
}
