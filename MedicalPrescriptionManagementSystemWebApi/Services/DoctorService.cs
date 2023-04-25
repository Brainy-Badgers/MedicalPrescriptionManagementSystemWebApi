using AutoMapper;
using MedicalPrescriptionManagementSystemWebApi.Data;
using MedicalPrescriptionManagementSystemWebApi.Models;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DoctorService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DoctorUpsertDto> GetDoctorDetailsByUserIdAsync(string userId)
        {
            DoctorUpsertDto doctorDetailsDto = new DoctorUpsertDto();
            var userDetails = await _dbContext.Users.Include(u => u.Doctor).FirstOrDefaultAsync(u => u.Id == userId);
            doctorDetailsDto = _mapper.Map<DoctorUpsertDto>(userDetails);
            return doctorDetailsDto;
        }
    }
}
