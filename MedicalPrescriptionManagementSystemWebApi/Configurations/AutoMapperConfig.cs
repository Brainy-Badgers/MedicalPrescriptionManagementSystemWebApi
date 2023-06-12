using AutoMapper;
using MedicalPrescriptionManagementSystemWebApi.Models;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;

namespace MedicalPrescriptionManagementSystemWebApi.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Medicine, MedicineUpsertDto>().ReverseMap();
            CreateMap<ApplicationUser, UserUpsertDto>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<ApplicationUser, DoctorUpsertDto>()
                        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                        .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => src.DOB))
                        .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Doctor.Specialization))
                        .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.Doctor.HospitalName))
                        .ForMember(dest => dest.ContactNo, opt => opt.MapFrom(src => src.Doctor.ContactNo))
                        .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.Doctor.DoctorId))
                        .ReverseMap();
            CreateMap<ApplicationUser, PharmacistUpsertDto>()
                        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                        .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => src.DOB))
                        .ForMember(dest => dest.AddressNo, opt => opt.MapFrom(src => src.Pharmacist.AddressNo))
                        .ForMember(dest => dest.AddressLine01, opt => opt.MapFrom(src => src.Pharmacist.AddressLine01))
                        .ForMember(dest => dest.AddressLine02, opt => opt.MapFrom(src => src.Pharmacist.AddressLine02))
                        .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Pharmacist.City))
                        .ForMember(dest => dest.ContactNo, opt => opt.MapFrom(src => src.Pharmacist.ContactNo))
                        .ReverseMap();
            CreateMap<Patient, PatientUpsertDto>().ReverseMap();

            CreateMap<Prescription, PrescriptionUpsertDto>()
                   .ForMember(dest => dest.PrescriptionId, opt => opt.MapFrom(src => src.PrescriptionId))
                   .ForMember(dest => dest.PrescriptionDescription, opt => opt.MapFrom(src => src.PrescriptionDescription))
                   .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                   .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                   .ForMember(dest => dest.IsComplete, opt => opt.MapFrom(src => src.IsComplete))
                   .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                   .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn))
                   .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                   .ForMember(dest => dest.medicinePrescriptionUpsertDtos, opt => opt.MapFrom(src => src.MedicinePrescriptions))
                .ReverseMap();
            CreateMap<MedicinePrescription, MedicinePrescriptionUpsertDto>()
                .ForMember(dest => dest.medicineUpsertDto, opt => opt.MapFrom(src => src.Medicine))
                .ReverseMap();
        }
    }
}
