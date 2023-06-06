using MedicalPrescriptionManagementSystemWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPrescriptionManagementSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var userList = await _userService.GetUserListAsync();
            return Ok(userList);
        }

        [HttpPost("userActivation")]
        public async Task<IActionResult> UserActivation(int activation, string userId)
        {
            bool result = await _userService.UpdateActiveStatus(activation, userId);
            return Ok();
        }

        [HttpPost("GetUserDetailsById")]
        public async Task<IActionResult> GetuserDetailsById(string userId)
        {
            var userDetails = await _userService.GetUserById(userId);
            if (userDetails == null)
            {
                return NotFound();
            }
            return Ok(userDetails);
        }
    }
}
