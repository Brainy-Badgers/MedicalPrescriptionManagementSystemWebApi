namespace MedicalPrescriptionManagementSystemWebApi.Models.Dtos
{
    public class MedicineCreateDto
    {
        public string MedicineName { get; set; }
        public string MedicineShortCode { get; set; }
        public string Purpose { get; set; }
        public int Qty { get; set; }
        public decimal AveragePricePerUnit { get; set; }
        public string Description { get; set; }
    }
}
