using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public interface IPharmacistService
    {
        Task<PharmacistUpsertDto> GetPharmacistDetailsByUserIdAsync(string userId);
    }
}
