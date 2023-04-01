namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class Pharmacist
    {
        public int PharmacistId { get; set; }
        public string? AddressNo { get; set; }
        public string? AddressLine01 { get; set; }
        public string? AddressLine02 { get; set; }
        public string? City { get; set; }
        public string? ContactNo { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string UserId { get; set; }
    }
}
