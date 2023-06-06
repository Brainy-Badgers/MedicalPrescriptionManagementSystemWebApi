using MedicalPrescriptionManagementSystemWebApi.Models;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public interface IMedicineService
    {
        Task<List<MedicineUpsertDto>> GetMedicineListAsync();
        Task<bool> AddNewMedicineAsync(Medicine medicine);
        Task<MedicineSharedDataListDto> GetAllMedicineSharedData();
        Task<bool> UpdateMedicineAsync(MedicineUpsertDto medicineUpsertDto);
        Task<MedicineUpsertDto> GetMedicineByIdAsync(int medicineId);
        Task<bool> DeleteMedicineByIdAsync(int medicineId);
    }
}
