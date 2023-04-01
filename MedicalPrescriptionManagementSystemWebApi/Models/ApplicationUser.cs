using Microsoft.AspNetCore.Identity;
using System.Numerics;

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

        public Pharmacist Pharmacist { get; set; }
        public Doctor Doctor { get; set; }
    }
}
