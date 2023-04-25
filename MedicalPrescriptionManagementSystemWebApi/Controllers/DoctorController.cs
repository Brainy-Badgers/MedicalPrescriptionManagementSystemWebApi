using MedicalPrescriptionManagementSystemWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPrescriptionManagementSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpPost("GetDoctorDetails")]
        public async Task<IActionResult> GetDoctorDetailsByUserId(string userId)
        {
            var doctorDetails = await _doctorService.GetDoctorDetailsByUserIdAsync(userId);

            if (doctorDetails == null)
                return NotFound();

            return Ok(doctorDetails);
        }
    }
}
