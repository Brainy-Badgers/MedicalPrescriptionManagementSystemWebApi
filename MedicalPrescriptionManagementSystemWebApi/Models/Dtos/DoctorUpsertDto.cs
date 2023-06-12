namespace MedicalPrescriptionManagementSystemWebApi.Models.Dtos
{
    public class DoctorUpsertDto
    {
        public string UserId { get; set; }
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Specialization { get; set; }
        public string HospitalName { get; set; }
        public string? ContactNo { get; set; }
    }
}
