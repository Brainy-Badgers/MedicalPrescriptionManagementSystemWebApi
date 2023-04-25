using AutoMapper;
using MedicalPrescriptionManagementSystemWebApi.Data;
using MedicalPrescriptionManagementSystemWebApi.Models;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public PatientService(ApplicationDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task<PatientUpsertDto> GetPatientByIdAsync(int patientId)
        {
            var patientDetails = await _dbContext.Patients.FirstOrDefaultAsync(p => p.PatientId == patientId);
            return _mapper.Map<PatientUpsertDto>(patientDetails);
        }
        public async Task<List<PatientUpsertDto>> GetAllPatientsAsync()
        {
            var patientDetails = await _dbContext.Patients.Where(p => p.IsActive != false).ToListAsync();
            return _mapper.Map<List<PatientUpsertDto>>(patientDetails);
        }

        public async Task<bool> CreatePatientAsync(PatientUpsertDto patientUpsertDto)
        {
            await _dbContext.Patients.AddAsync(_mapper.Map<Patient>(patientUpsertDto));
            var result = await _dbContext.SaveChangesAsync();

            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdatePatientAsync(PatientUpsertDto patientUpsertDto)
        {
            _dbContext.Patients.Update(_mapper.Map<Patient>(patientUpsertDto));
            var result = await _dbContext.SaveChangesAsync();

            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> DeletePatient(int patientId)
        {
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.PatientId == patientId);

            if (patient == null)
                return false;

            patient.IsActive = false;
            _dbContext.Patients.Update(patient);
            var result = await _dbContext.SaveChangesAsync();

            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
