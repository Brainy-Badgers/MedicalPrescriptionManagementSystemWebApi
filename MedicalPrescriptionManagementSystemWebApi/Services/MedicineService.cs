using AutoMapper;
using MedicalPrescriptionManagementSystemWebApi.Data;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using MedicalPrescriptionManagementSystemWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MedicineService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MedicineUpsertDto>> GetMedicineListAsync()
        {
            var list = await _context.Medicines.Where(m => m.IsActive != false).ToListAsync();
            List<MedicineUpsertDto> medicineList = _mapper.Map<List<MedicineUpsertDto>>(list);
            return medicineList;
        }

        public async Task<bool> AddNewMedicineAsync(Medicine medicine)
        {
            medicine.CreatedOn = DateTime.UtcNow;
            medicine.IsActive = true;

            _context.Medicines.Add(medicine);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return true;
            return false;
        }

        public async Task<MedicineSharedDataListDto> GetAllMedicineSharedData()
        {
            MedicineSharedDataListDto medicineSharedDataList = new MedicineSharedDataListDto();
            medicineSharedDataList.Medicines = await _context.Medicines.ToListAsync();
            medicineSharedDataList.Dosages = await _context.Dosages.ToListAsync();
            medicineSharedDataList.DosageFrequencies = await _context.DosageFrequencies.ToListAsync();

            return medicineSharedDataList;
        }
        public async Task<bool> UpdateMedicineAsync(MedicineUpsertDto medicineUpsertDto)
        {
            var medicine = _mapper.Map<Medicine>(medicineUpsertDto);
            medicine.UpdatedOn = DateTime.Now;

            _context.Medicines.Update(medicine);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<MedicineUpsertDto> GetMedicineByIdAsync(int medicineId)
        {
            var medicine = await _context.Medicines.FirstOrDefaultAsync(m => m.MedicineId == medicineId);
            if (medicine != null)
                return _mapper.Map<MedicineUpsertDto>(medicine);

            return null;

        }

    }
}
