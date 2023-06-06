namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class Prescription : BaseModel
    {
        public int PrescriptionId { get; set; }
        public string? PrescriptionDescription { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public bool IsComplete { get; set; }
        public List<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
