using MedicalPrescriptionManagementSystemWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPrescriptionManagementSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacistController : ControllerBase
    {
        private readonly IPharmacistService _phamacistService;

        public PharmacistController(IPharmacistService phamacistService)
        {
            _phamacistService = phamacistService;
        }

        [HttpPost("GetPharmacistDetailsByUserId")]
        public async Task<IActionResult> GetPharmacistDetailsByUserId(string userId)
        {
            var pharmacistDetail = await _phamacistService.GetPharmacistDetailsByUserIdAsync(userId);
            if (pharmacistDetail == null)
            {
                return NotFound();
            }
            return Ok(pharmacistDetail);
        }
    }
}
