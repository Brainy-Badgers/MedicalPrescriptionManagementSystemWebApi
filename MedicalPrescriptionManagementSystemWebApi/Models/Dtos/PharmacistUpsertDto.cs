namespace MedicalPrescriptionManagementSystemWebApi.Models.Dtos
{
    public class PharmacistUpsertDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string? AddressNo { get; set; }
        public string? AddressLine01 { get; set; }
        public string? AddressLine02 { get; set; }
        public string? City { get; set; }
        public string? ContactNo { get; set; }
    }
}
