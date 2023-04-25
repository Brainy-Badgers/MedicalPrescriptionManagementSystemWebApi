using AutoMapper;
using MedicalPrescriptionManagementSystemWebApi.Data;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public class PharmacistService : IPharmacistService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public PharmacistService(ApplicationDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task<PharmacistUpsertDto> GetPharmacistDetailsByUserIdAsync(string userId)
        {
            PharmacistUpsertDto pharmacistDetailsDto = new PharmacistUpsertDto();
            var userDetails = await _dbContext.Users.Include(u => u.Pharmacist).FirstOrDefaultAsync(u => u.Id == userId);
            pharmacistDetailsDto = _mapper.Map<PharmacistUpsertDto>(userDetails);
            return pharmacistDetailsDto;
        }
    }
}
