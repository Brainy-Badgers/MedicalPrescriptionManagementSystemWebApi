namespace MedicalPrescriptionManagementSystemWebApi.Models.Dtos
{
    public class MedicineListReadDto
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineShortCode { get; set; }
        public string Purpose { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public decimal AveragePricePerUnit { get; set; }
    }
}
