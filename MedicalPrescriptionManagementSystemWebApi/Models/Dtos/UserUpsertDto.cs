namespace MedicalPrescriptionManagementSystemWebApi.Models.Dtos
{
    public class UserUpsertDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int ActiveStatus { get; set; }
        public string UserType { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ConfirmationFileUrl { get; set; }
        public string? ProfilePicUrl { get; set; }
    }
}
