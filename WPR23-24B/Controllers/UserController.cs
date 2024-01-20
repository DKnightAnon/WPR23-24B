using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using WPR23_24B.Models;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Services;

namespace WPR23_24B.Controllers
{
    [Authorize(Roles = "Ervaringsdeskundige")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<Gebruiker> _userManager;

        public UserController(UserManager<Gebruiker> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("userinfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            // Retrieve the user's information from claims
            var userId = User.FindFirst("Id")?.Value;

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            // Extract additional claims from the JWT token
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            // Set properties based on the user type
            var ervaringsdeskundige = user as Ervaringsdeskundige;

            // Retrieve all other properties directly from the user object
            var userInformation = new
            {
                UserId = user.Id,
                UserName = user.UserName,
                Emailadres = userEmail,
                Role = userRole,
                Naam = user.Naam,
                Postcode = user.Postcode,
                TelefoonNummer = user.TelefoonNummer,

                GeboorteDatum = ervaringsdeskundige?.GeboorteDatum,
                BenaderingTelefonisch = ervaringsdeskundige?.BenaderingTelefonisch ?? false,
                BenaderingPortal = ervaringsdeskundige?.BenaderingPortal ?? false,
                BenaderingCommercieel = ervaringsdeskundige?.BenaderingCommercieel ?? false,
                IsJongerDan18 = ervaringsdeskundige?.IsJongerDan18 ?? false,
                VoogdId = ervaringsdeskundige?.VoogdId,
                Beperkingen = ervaringsdeskundige?.ErvaringsdeskundigeBeperkingen,
                Hulpmiddellen = ervaringsdeskundige?.Hulpmiddelen,
            };

            return Ok(userInformation);
        }

        [HttpPut("updateuserinfo")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UserInfoUpdateModel model)
        {
            try
            {
                var userId = User.FindFirst("Id")?.Value;
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Update user information based on the model
                user.Naam = model.Naam;
                user.Email = model.Emailadres;
                // ... update other properties

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    // Return updated user information
                    var updatedUserInfo = new
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        // ... return other properties as needed
                    };
                    return Ok(updatedUserInfo);
                }
                else
                {
                    return BadRequest("Failed to update user information");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
