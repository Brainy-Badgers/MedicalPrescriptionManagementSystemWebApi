using AutoMapper;
using MedicalPrescriptionManagementSystemWebApi.Data;
using MedicalPrescriptionManagementSystemWebApi.Extension;
using MedicalPrescriptionManagementSystemWebApi.Models;
using MedicalPrescriptionManagementSystemWebApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalPrescriptionManagementSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public AuthController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, ApplicationDbContext context, IEmailService emailService,
             IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
            _emailService = emailService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin(AdminRegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse { Status = "Error", Message = "User already exists!" });

            if (model.AdminCreateSecret != _configuration.GetValue<int>("AdminCreateSecret"))
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse { Status = "Error", Message = "Admin Creation Secret is Incorrect" });

            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DOB = model.DOB,
                IsActive = true,
                CreatedOn = DateTime.UtcNow
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse { Status = "Error", Message = "Admin creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.ADMIN))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.ADMIN));
            if (!await _roleManager.RoleExistsAsync(UserRoles.DOCTOR))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.DOCTOR));
            if (!await _roleManager.RoleExistsAsync(UserRoles.PHARMACIST))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.PHARMACIST));

            if (await _roleManager.RoleExistsAsync(UserRoles.ADMIN))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.ADMIN);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.DOCTOR))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.DOCTOR);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.PHARMACIST))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.PHARMACIST);
            }
            await _emailService.SendEmailAsSystemAsync(user.Email, "Admin Registration - MPMS", "User created successfully!");
            return Ok(new ApiResponse { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("RegisterDoctor")]
        public async Task<IActionResult> RegisterDoctor(DoctorRegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse { Status = "Error", Message = "User already exists!" });

            Doctor doctor = new Doctor()
            {
                Specialization = model.Specialization,
                HospitalName = model.HospitalName,
                ContactNo = model.ContactNo,
            };

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DOB = model.DOB,
                IsActive = true,
                CreatedOn = DateTime.UtcNow,
                Doctor = doctor
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (await _roleManager.RoleExistsAsync(UserRoles.DOCTOR))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.DOCTOR);
            }
            await _emailService.SendEmailAsSystemAsync(user.Email, "Doctor Registration - MPMS", "User created successfully!");
            return Ok(new ApiResponse { Status = "Success", Message = "User created successfully!" });
        }


        [HttpPost]
        [Route("RegisterPharmacist")]
        public async Task<IActionResult> RegisterPharmacist(PharmacistRegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse { Status = "Error", Message = "User already exists!" });

            Pharmacist pharmacist = new Pharmacist
            {
                AddressNo = model.AddressNo,
                AddressLine01 = model.AddressLine01,
                AddressLine02 = model.AddressLine02,
                City = model.City,
                ContactNo = model.ContactNo,
            };

            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DOB = model.DOB,
                IsActive = true,
                CreatedOn = DateTime.UtcNow,
                Pharmacist = pharmacist
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (await _roleManager.RoleExistsAsync(UserRoles.PHARMACIST))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.PHARMACIST);
            }
            await _emailService.SendEmailAsSystemAsync(user.Email, "Pharmacist Registration - MPMS", "User created successfully!");
            return Ok(new ApiResponse { Status = "Success", Message = "User created successfully!" });
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRolesList = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRolesList)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetJwtToken(authClaims);

                return Ok(new
                {
                    token = token,
                    userType = userRolesList.Any(r => r == UserRoles.ADMIN) ? UserRoles.ADMIN : userRolesList.First()
                });
            }
            return Unauthorized();
        }

        [HttpGet("TestEmailApi")]
        public async Task<IActionResult> TestEmailAsync()
        {
            await _emailService.SendEmailAsSystemAsync("medicalprescriptionmanagementr@gmail.com", "Test mail", "This is a test email from MPMS");
            return Ok();
        }
        private string GetJwtToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddSeconds(Convert.ToDouble(_configuration["JWT:TokenLifetimeInSeconds"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
