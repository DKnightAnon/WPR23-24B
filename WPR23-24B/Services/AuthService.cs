using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using WPR23_24B.DTO;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Gebruiker> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRolService _rolService;

        public AuthService(
            UserManager<Gebruiker> userManager,
            IConfiguration configuration,
            ILogger<AuthService> logger,
            RoleManager<IdentityRole> roleManager,
            IRolService rolService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
            _roleManager = roleManager;
            _rolService = rolService;
        }

        public async Task<bool> SignInAsync(SignInDTO model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email!);

                if (user != null)
                {
                    _logger.LogInformation($"User found for email: {model.Email}");

                    var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password!);

                    if (passwordValid)
                    {
                        _logger.LogInformation($"Password is valid for user: {model.Email}");
                        return true; // Sign-in successful
                    }
                    else
                    {
                        _logger.LogWarning($"Invalid password for user: {model.Email}");
                    }
                }
                else
                {
                    _logger.LogWarning($"User not found for email: {model.Email}");
                }

                return false; // Sign-in failed
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during user sign-in");
                return false;
            }
        }

        public async Task<string> GenerateJwtToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var claims = new List<Claim>
            {
                //These two claims caused the AuthServiceTest.GenerateJwtToken_ReturnsValidToken() to fail. 
                //Added extra values to the mock user. Tests now pass.
                new Claim("Id", user.Id),
                new Claim("UserName", user.UserName),
                new Claim(ClaimTypes.Email, user!.Email!),
                new Claim(ClaimTypes.Role, await _rolService.GetUserRole(user)),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                // TODO: Make it configurable?
                // expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["Jwt:ExpirationHours"])), 
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RefreshResult> RefreshTokenAsync(string refreshToken)
        {
            // var storedToken = await _dbContext.RefreshTokens
            //     .SingleOrDefaultAsync(t => t.Token == refreshToken);

            // if (storedToken == null || storedToken.Expired)
            // {
            //     return new RefreshResult { Success = false };
            // }

            // // Generate a new access token
            // var email = _userManager.GetUserId(storedToken.UserId);
            // var newAccessToken = await GenerateJwtToken(email);

            // // Update the expiration of the refresh token
            // storedToken.Expires = DateTime.UtcNow.AddMonths(1); // Refresh token expiration

            // // Save changes to the database
            // await _dbContext.SaveChangesAsync();

            return new RefreshResult
            {
                Success = true,
                // Token = newAccessToken
            };
        }

        public async Task<string> GenerateRefreshToken(Gebruiker user)
        {
            // TODO:
            // Implement the logic to generate a refresh token here
            var refreshToken = Guid.NewGuid().ToString();

            return refreshToken;

        }
    }
}