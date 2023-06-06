namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class Patient : BaseModel
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string NIC { get; set; }
        public string Email { get; set; }
        public string TelephoneNo { get; set; }
        public string AddressLine01 { get; set; }
        public string AddressLine02 { get; set; }
        public string City { get; set; }
        public string ProfilePicUrl { get; set; }

    }
}
