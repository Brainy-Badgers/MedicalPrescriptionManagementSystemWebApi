using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using MedicalPrescriptionManagementSystemWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPrescriptionManagementSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("GetPatientDetailsById")]
        public async Task<IActionResult> GetPatientDetailsById(int patientId)
        {
            var patientDetails = await _patientService.GetPatientByIdAsync(patientId);
            if (patientDetails == null)
            {
                return NotFound();
            }

            return Ok(patientDetails);
        }

        [HttpPost("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var patientList = await _patientService.GetAllPatientsAsync();
            if (patientList == null)
            {
                return NotFound();
            }

            return Ok(patientList);
        }

        [HttpPost("CreatePatient")]
        public async Task<IActionResult> CratePatient(PatientUpsertDto patientUpsertDto)
        {
            var isSucess = await _patientService.CreatePatientAsync(patientUpsertDto);

            if (!isSucess)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }

        [HttpPost("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(PatientUpsertDto patientUpsertDto)
        {
            var isSucess = await _patientService.UpdatePatientAsync(patientUpsertDto);

            if (!isSucess)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }

        [HttpDelete("DeletePatient")]
        public async Task<IActionResult> DeletePatientById(int patientId) 
        {
            var isSucess = await _patientService.DeletePatient(patientId);

            if (!isSucess)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }
    }
}
