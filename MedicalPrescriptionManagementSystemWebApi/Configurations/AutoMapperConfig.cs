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
            CreateMap<UserUpsertDto, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, DoctorUpsertDto>()
                        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                        .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => src.DOB))
                        .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Doctor.Specialization))
                        .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.Doctor.HospitalName))
                        .ForMember(dest => dest.ContactNo, opt => opt.MapFrom(src => src.Doctor.ContactNo))
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
        }
    }
}
