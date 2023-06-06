using Microsoft.AspNetCore.Identity;

namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public int ActiveStatus { get; set; } //1-active, 2-deactivate, 3-pending
        public string? ConfirmationFileUrl { get; set; }
        public string? ProfilePicUrl { get; set; }
        public Pharmacist Pharmacist { get; set; }
        public Doctor Doctor { get; set; }
    }
}
