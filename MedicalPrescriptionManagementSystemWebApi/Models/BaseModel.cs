namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class BaseModel
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
