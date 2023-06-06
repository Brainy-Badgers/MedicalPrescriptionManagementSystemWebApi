using AutoMapper;
using MedicalPrescriptionManagementSystemWebApi.Data;
using MedicalPrescriptionManagementSystemWebApi.Models;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<UserUpsertDto>> GetUserListAsync()
        {
            var users = await _context.Users.ToListAsync();
            List<UserUpsertDto> userUpsertDtos = new List<UserUpsertDto>();

            for(int i =0; i < users.Count; i++)
            {
                UserUpsertDto dto = _mapper.Map<UserUpsertDto>(users[i]);
                var userRolesist = await _userManager.GetRolesAsync(users[i]);
                dto.UserType = userRolesist.Count > 1 ? "Admin":userRolesist.FirstOrDefault() ;
                userUpsertDtos.Add(dto);    
            }

            return userUpsertDtos;
        }

        public async Task<bool> UpdateActiveStatus(int activation, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return false;

            user.ActiveStatus = activation;
            await _userManager.UpdateAsync(user);
            return true;
        }

        public async Task<UserUpsertDto> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var userUpsertDto = _mapper.Map<UserUpsertDto>(user);
            userUpsertDto.UserType = userRoles.Count > 1 ? "Admin" : userRoles.FirstOrDefault();
            return userUpsertDto;
        }


    }
}
