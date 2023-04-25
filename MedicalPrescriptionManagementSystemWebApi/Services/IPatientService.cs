using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public interface IPatientService
    {
        Task<PatientUpsertDto> GetPatientByIdAsync(int patientId);
        Task<List<PatientUpsertDto>> GetAllPatientsAsync();
        Task<bool> CreatePatientAsync(PatientUpsertDto patientUpsertDto);
        Task<bool> UpdatePatientAsync(PatientUpsertDto patientUpsertDto);
        Task<bool> DeletePatient(int patientId);
    }
}
