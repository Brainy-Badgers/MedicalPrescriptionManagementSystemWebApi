namespace MedicalPrescriptionManagementSystemWebApi.Models.Dtos
{
    public class PrescriptionUpsertDto
    {
        public int PrescriptionId { get; set; }
        public string? PrescriptionDescription { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public string? PatientName { get; set; }
        public string? DoctorFirstName { get; set; }
        public string? DoctorLastName { get; set; }
        public string? Specialization { get; set; }
        public string? HospitalName { get; set; }
        public string? ContactNo { get; set; }
        public List<MedicinePrescriptionUpsertDto> medicinePrescriptionUpsertDtos { get; set; }
    }
}
