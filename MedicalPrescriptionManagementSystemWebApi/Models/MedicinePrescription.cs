﻿namespace MedicalPrescriptionManagementSystemWebApi.Models
{
    public class MedicinePrescription
    {
        public int MedicinePrescriptionId { get; set; }
        public int MedicineQty { get; set; }
        public bool IsComplete { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? Dosage { get; set; }
        public string? DosageFrequency { get; set; }

        public Medicine Medicine { get; set; }
        public int MedicineId { get; set; }
        public Prescription Prescription { get; set; }
        public int PrescriptionId { get; set; }


    }
}
