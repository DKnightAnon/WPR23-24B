using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WPR23_24B.DTO;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Services;

namespace WPR23_24B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IRolService _rolService;
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<Gebruiker> _userManager;
        // private readonly IJwtService _jwtService; 

        public AuthController(
            IAuthService authService,
            IRolService rolService,
            UserManager<Gebruiker> userManager,
            ILogger<AuthController> logger)
        // IJwtService jwtService)
        {
            _authService = authService;
            _rolService = rolService;
            _userManager = userManager;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInDTO model)
        {
            _logger.LogInformation($"Attempting sign-in for email: {model.Email}");

            if (model == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.SignInAsync(model);

            if (result)
            {
                var token = await _authService.GenerateJwtToken(model.Email!);
                _logger.LogInformation($"JWT token generated for user {model.Email}: {token}");

                // Get user role
                var user = await _userManager.FindByEmailAsync(model.Email!);
                var userRole = await _rolService.GetUserRole(user!);

                // Set content type to JSON!
                Response.Headers.Add("Content-Type", "application/json");


                return Ok(new { Message = "Login Succesfull", Token = token, UserRole = userRole });

            }
            else
            {
                return BadRequest(new { Message = "Login failed", Errors = "Invalid username or password" });
            }
        }

        [AllowAnonymous]
        [HttpGet("checkrole")]
        public async Task<IActionResult> CheckRole([FromQuery] string userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
            {
                return BadRequest("Email is required.");
            }

            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var userRole = await _rolService.GetUserRole(user);

            return Ok(new { Email = user.Email, Role = userRole });
        }
    }
}