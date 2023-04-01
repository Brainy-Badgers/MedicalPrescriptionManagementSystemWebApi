namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Specialization { get; set; }
        public string HospitalName { get; set; }
        public string? ContactNo { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string UserId { get; set; }
    }
}
