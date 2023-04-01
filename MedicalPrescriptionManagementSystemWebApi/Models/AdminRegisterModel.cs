﻿namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class AdminRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int AdminCreateSecret { get; set; }
    }
}
