using AutoMapper;
using MedicalPrescriptionManagementSystemWebApi.Data;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using MedicalPrescriptionManagementSystemWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public class MedicineService :IMedicineService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MedicineService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MedicineListReadDto>> GetMedicineListAsync()
        {
            var list = await _context.Medicines.ToListAsync();
            List<MedicineListReadDto> medicineList = _mapper.Map<List<MedicineListReadDto>>(list);
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
    }
}
