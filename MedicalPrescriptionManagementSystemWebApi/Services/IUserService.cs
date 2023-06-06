using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public interface IUserService
    {
        Task<List<UserUpsertDto>> GetUserListAsync();
        Task<bool> UpdateActiveStatus(int activation, string userId);
        Task<UserUpsertDto> GetUserById(string userId);
    }
}
