using MedicalPrescriptionManagementSystemWebApi.Models;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using MedicalPrescriptionManagementSystemWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPrescriptionManagementSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpPost("GetPrescriptionById")]
        public async Task<IActionResult> GetPrescriptionById(int prescriptionId)
        {
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(prescriptionId);
            if (prescription == null) { return NotFound(); }
            return Ok(prescription);
        }

        [HttpPost("CreatePrescription")]
        public async Task<IActionResult> CreatePrescription(PrescriptionUpsertDto prescription)
        {
            bool isSucess = await _prescriptionService.CreatePrescription(prescription);
            if (isSucess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("UpdatePrescription")]
        public async Task<IActionResult> UpdatePrescription(PrescriptionUpsertDto prescription)
        {
            bool isSucess = await _prescriptionService.UpdatePrescription(prescription);
            if (isSucess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("GetPatientHistoryByPatientId")]
        public async Task<IActionResult> GetPatientHistoryByPatientId(int patientId)
        {
            var prescriptionList = await _prescriptionService.GetPatientHistoryByPatientId(patientId);
            if (prescriptionList.Count > 0)
            {
                return Ok(prescriptionList);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
