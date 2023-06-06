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
        public List<MedicinePrescriptionUpsertDto> medicinePrescriptionUpsertDtos { get; set; }
    }
}
