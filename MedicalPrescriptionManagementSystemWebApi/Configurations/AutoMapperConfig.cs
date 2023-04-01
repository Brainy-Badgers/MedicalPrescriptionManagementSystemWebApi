using AutoMapper;
using MedicalPrescriptionManagementSystemWebApi.Models;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;

namespace MedicalPrescriptionManagementSystemWebApi.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Medicine,MedicineListReadDto>().ReverseMap();
            CreateMap<MedicineCreateDto, Medicine>().ReverseMap();
        }
    }
}
