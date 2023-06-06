using AutoMapper;
using MedicalPrescriptionManagementSystemWebApi.Data;
using MedicalPrescriptionManagementSystemWebApi.Models;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public PrescriptionService(ApplicationDbContext context, IMapper mapper, IConfiguration configuration, IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _emailService = emailService;
        }
        public async Task<PrescriptionUpsertDto> GetPrescriptionByIdAsync(int prescriptionId)
        {
            var prescrption = await _context.Prescriptions.Include(p => p.MedicinePrescriptions).FirstOrDefaultAsync(p => p.PrescriptionId == prescriptionId);
            var prescriptionUpserDto = _mapper.Map<PrescriptionUpsertDto>(prescrption);
            return prescriptionUpserDto;
        }

        public async Task<bool> CreatePrescription(PrescriptionUpsertDto prescriptionUpsertDto)
        {
            Prescription prescription = new Prescription
            {
                PrescriptionDescription = prescriptionUpsertDto.PrescriptionDescription,
                PatientId = prescriptionUpsertDto.PatientId,
                DoctorId = prescriptionUpsertDto.DoctorId,
                IsActive = prescriptionUpsertDto.IsActive,
                IsComplete = prescriptionUpsertDto.IsComplete,
                CreatedOn = DateTime.Now,
            };
            await _context.Prescriptions.AddAsync(prescription);
            var prescriptionCreateResult = await _context.SaveChangesAsync();

            if (prescriptionCreateResult > 0)
            {
                foreach (var medicinePrescription in prescriptionUpsertDto.medicinePrescriptionUpsertDtos)
                {
                    MedicinePrescription medicinePrescriptionModel = _mapper.Map<MedicinePrescription>(medicinePrescription);
                    medicinePrescriptionModel.PrescriptionId = prescription.PrescriptionId;
                    medicinePrescriptionModel.MedicinePrescriptionId = 0;
                    await _context.MedicinePrescriptions.AddAsync(medicinePrescriptionModel);
                }
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    await SendPrescriptionToPatientByPrescriptionId(prescription.PrescriptionId);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> UpdatePrescription(PrescriptionUpsertDto prescriptionUpsertDto)
        {
            Prescription prescription = new Prescription
            {
                PrescriptionId = prescriptionUpsertDto.PrescriptionId,
                PrescriptionDescription = prescriptionUpsertDto.PrescriptionDescription,
                PatientId = prescriptionUpsertDto.PatientId,
                DoctorId = prescriptionUpsertDto.DoctorId,
                IsActive = prescriptionUpsertDto.IsActive,
                IsComplete = prescriptionUpsertDto.IsComplete,
                UpdatedOn = DateTime.Now,
                CreatedOn = prescriptionUpsertDto.CreatedOn
            };
            _context.Prescriptions.Update(prescription);
            var prescriptionUpdateResult = await _context.SaveChangesAsync();

            if (prescriptionUpdateResult > 0)
            {
                foreach (var medicinePrescription in prescriptionUpsertDto.medicinePrescriptionUpsertDtos)
                {
                    MedicinePrescription medicinePrescriptionModel = _mapper.Map<MedicinePrescription>(medicinePrescription);
                    medicinePrescriptionModel.PrescriptionId = prescription.PrescriptionId;
                    _context.MedicinePrescriptions.Update(medicinePrescriptionModel);
                }
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task SendPrescriptionToPatientByPrescriptionId(int prescriptionId)
        {
            Prescription prescription = await _context.Prescriptions.FirstOrDefaultAsync(p => p.PrescriptionId == prescriptionId);
            if (prescription != null)
            {
                Patient patient = await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == prescription.PatientId);
                if (patient != null)
                {
                    var qrLink = string.Concat(_configuration.GetValue<string>("ClientAppBaseUrl"), _configuration.GetValue<string>("PrescriptionViewPageRoute"), prescription.PrescriptionId);
                    var emailSubject = _configuration.GetValue<string>("PrescriptionEmailSubject");
                    var emailbody = String.Format( _configuration.GetValue<string>("PrescriptionEmailBody"),patient.FirstName,prescription.PrescriptionId, qrLink);
                    
                    await _emailService.SendQREmailAsSystemAsync(patient.Email, emailSubject, emailbody, qrLink);
                }
            }
        }
    }
}
