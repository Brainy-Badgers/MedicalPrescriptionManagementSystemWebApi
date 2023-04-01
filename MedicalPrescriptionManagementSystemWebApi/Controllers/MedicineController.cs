using AutoMapper;
using MedicalPrescriptionManagementSystemWebApi.Models.Dtos;
using MedicalPrescriptionManagementSystemWebApi.Models;
using MedicalPrescriptionManagementSystemWebApi.Services;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> AddNewMedicine(MedicineCreateDto medicineCreateDto)
        {
            Medicine medicine = _mapper.Map<Medicine>(medicineCreateDto);
            var isSuccess = await _medicineService.AddNewMedicineAsync(medicine);
            if (!isSuccess)
                return StatusCode(StatusCodes.Status406NotAcceptable, new ApiResponse { Status = "Erorr", Message = "Medicine Creation failed" });
            return Ok();
        }
    }
}
