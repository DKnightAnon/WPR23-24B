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
                var refreshToken = await _authService.GenerateRefreshToken(user);

                return Ok(new
                {
                    RefreshToken = refreshToken,
                    Message = "Login Successful",
                    Token = token,
                    UserRole = userRole,
                    //UserInfo = new
//                    {
//                        UserId = user.Id,
//                       UserName = user.UserName,
//                        Email = user.Email,
//                        Role = userRole, // You can include more user information as needed
//                                         // Include other properties from your user model
//                    }
                });
            }
            else
            {
                return BadRequest(new { error = "Invalid username or password" });

            }
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDTO model)
        {
            // Validate the refresh token and generate a new access token
            var result = await _authService.RefreshTokenAsync(model.RefreshToken);

            if (result.Success)
            {
                return Ok(new
                {
                    Token = result.Token,
                    // Other information if needed
                });
            }

            return BadRequest(new { error = "Invalid refresh token" });
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

        [AllowAnonymous]
        [HttpPost("claim-research")]
        public async Task<IActionResult> ClaimResearch([FromBody] SignInDTO model)
        {
            _logger.LogInformation($"Attempting research claim for email: {model.Email}");

            if (model == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.SignInAsync(model);

            if (result)
            {
                // Additional logic if needed

                return Ok(new { Message = "Research claimed successfully" });
            }
            else
            {
                return BadRequest(new { error = "Invalid email or password" });
            }
        }
    }
}
