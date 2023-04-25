namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class Dosage
    {
        public int DosageId { get; set; }
        public string DosageInfo { get; set; }
        public List<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
