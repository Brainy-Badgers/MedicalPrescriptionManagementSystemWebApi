using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public interface IDoctorService
    {
        Task<DoctorUpsertDto> GetDoctorDetailsByUserIdAsync(string userId);

    }
}
