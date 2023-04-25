namespace MedicalPrescriptionManagementSystemWebApi.Models.Dtos
{
    public class PatientUpsertDto
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
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
