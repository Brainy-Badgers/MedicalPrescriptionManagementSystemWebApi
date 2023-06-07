using MedicalPrescriptionManagementSystemWebApi.Models;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public interface IPrescriptionService
    {
        Task<PrescriptionUpsertDto> GetPrescriptionByIdAsync(int prescriptionId);
        Task<bool> CreatePrescription(PrescriptionUpsertDto prescriptionUpsertDto);
        Task<bool> UpdatePrescription(PrescriptionUpsertDto prescriptionUpsertDto);
        Task<List<PrescriptionUpsertDto>> GetPatientHistoryByPatientId(int patientId);
    }
}
