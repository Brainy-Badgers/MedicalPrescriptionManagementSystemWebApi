using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using MedicalPrescriptionManagementSystemWebApi.Models;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public interface IMedicineService
    {
        Task<List<MedicineListReadDto>> GetMedicineListAsync();
        Task<bool> AddNewMedicineAsync(Medicine medicine);
    }
}
