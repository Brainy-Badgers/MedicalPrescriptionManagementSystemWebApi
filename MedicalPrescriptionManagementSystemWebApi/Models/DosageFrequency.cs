namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class DosageFrequency
    {
        public int DosageFrequencyId { get; set; }
        public string DosageFrequencyInfo { get; set; }
        public List<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
