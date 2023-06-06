namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class PharmacistRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string? AddressNo { get; set; }
        public string? AddressLine01 { get; set; }
        public string? AddressLine02 { get; set; }
        public string? City { get; set; }
        public string? ContactNo { get; set; }
        public string? ConfirmationFileUrl { get; set; }
    }
}
