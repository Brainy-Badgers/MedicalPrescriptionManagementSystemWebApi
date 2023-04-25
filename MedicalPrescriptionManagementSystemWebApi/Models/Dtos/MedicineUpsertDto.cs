namespace MedicalPrescriptionManagementSystemWebApi.Models.Dtos
{
    public class MedicineUpsertDto
    {
        public int MedicineId { get; set; } = 0;
        public string MedicineName { get; set; }
        public string MedicineShortCode { get; set; }
        public string Purpose { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public decimal AveragePricePerUnit { get; set; }
    }
}
