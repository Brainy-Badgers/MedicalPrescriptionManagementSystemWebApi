using AutoMapper;
using MedicalPrescriptionManagementSystemWebApi.Models;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using MedicalPrescriptionManagementSystemWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPrescriptionManagementSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;
        public MedicineController(IMedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        [HttpPost("GetAllMedicine")]
        public async Task<IActionResult> GetAllMedicine()
        {
            var medicineList = await _medicineService.GetMedicineListAsync();
            return Ok(medicineList);
        }

        [HttpPost("AddNewMedicine")]
        public async Task<IActionResult> AddNewMedicine(MedicineUpsertDto medicineUpsertDto)
        {
            Medicine medicine = _mapper.Map<Medicine>(medicineUpsertDto);
            var isSuccess = await _medicineService.AddNewMedicineAsync(medicine);
            if (!isSuccess)
                return StatusCode(StatusCodes.Status406NotAcceptable, new ApiResponse { Status = "Erorr", Message = "Medicine Creation failed" });
            return Ok();
        }

        [HttpGet("GetMedicineSharedData")]
        public async Task<IActionResult> GetAllMedicineSharedData()
        {
            var medicineSharedData = await _medicineService.GetAllMedicineSharedData();
            return Ok(medicineSharedData);
        }

        [HttpPost("UpdateMedicine")]
        public async Task<IActionResult> UpdateMedicine(MedicineUpsertDto medicineUpsertDto)
        {
            bool isSucess = await _medicineService.UpdateMedicineAsync(medicineUpsertDto);
            if (!isSucess)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }

        [HttpGet("GetMedicineById")]
        public async Task<IActionResult> GetMedicineById(int medicineId) 
        {
            var medicine = await _medicineService.GetMedicineByIdAsync(medicineId);
            if(medicine == null)
                return NotFound();

            return Ok(medicine);    
        }
    }
}
