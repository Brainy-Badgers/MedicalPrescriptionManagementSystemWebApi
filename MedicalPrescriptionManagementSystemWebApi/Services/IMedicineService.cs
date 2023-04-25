using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using MedicalPrescriptionManagementSystemWebApi.Models;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public interface IMedicineService
    {
        Task<List<MedicineUpsertDto>> GetMedicineListAsync();
        Task<bool> AddNewMedicineAsync(Medicine medicine);
        Task<MedicineSharedDataListDto> GetAllMedicineSharedData();
        Task<bool> UpdateMedicineAsync(MedicineUpsertDto medicineUpsertDto);
        Task<MedicineUpsertDto> GetMedicineByIdAsync(int medicineId);
    }
}
