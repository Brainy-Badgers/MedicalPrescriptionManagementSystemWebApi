namespace MedicalPrescriptionManagementSystemWebApi.Models.Dtos
{
    public class MedicineSharedDataListDto
    {
        public List<Medicine> Medicines { get; set; }
        public List<Dosage> Dosages { get; set; }
        public List<DosageFrequency> DosageFrequencies { get; set; }
    }
}
