using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Data;
using WPR23_24B.Models;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Models.Onderzoek;
using WPR23_24B.Services;

namespace WPR23_24B.Controllers
{
    [Authorize(Roles = "Ervaringsdeskundige")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<Gebruiker> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserController> _logger;

        public UserController(UserManager<Gebruiker> userManager, ApplicationDbContext context, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        // GET method to retrieve user information
        [HttpGet("userinfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            // Retrieve the user's information from claims
            var userId = User.FindFirst("Id")?.Value;

            // Find the user in the database
            var user = await _userManager.FindByIdAsync(userId);

            // Return a 404 response if the user is not found
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
            // Create an anonymous object with user information
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

        // PUT method to update user information
        [HttpPut("updateuserinfo")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UserInfoUpdateModel model)
        {
            try
            {
                // Retrieve the user's ID from claims
                var userId = User.FindFirst("Id")?.Value;
                // Find the user in the database
                var user = await _userManager.FindByIdAsync(userId);

                // Return a 404 response if the user is not found
                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Check if the user is an Ervaringsdeskundige
                if (user is not Ervaringsdeskundige ervaringsdeskundige)
                {
                    return BadRequest("User is not an Ervaringsdeskundige");
                }

                // Log received model
                _logger.LogInformation("Received UserInfoUpdateModel: {@Model}", model);


                // Update user information based on the model
                if (model.Naam != null)
                    ervaringsdeskundige.Naam = model.Naam;

                if (model.Emailadres != null)
                    ervaringsdeskundige.Email = model.Emailadres;

                if (model.TelefoonNummer != null)
                    ervaringsdeskundige.TelefoonNummer = model.TelefoonNummer;

                if (model.Postcode != null)
                    ervaringsdeskundige.Postcode = model.Postcode;

                if (model.GeboorteDatum != null)
                    ervaringsdeskundige.GeboorteDatum = model.GeboorteDatum;

                // ... update other properties

                // Update the user in the database
                var result = await _userManager.UpdateAsync(ervaringsdeskundige);

                // Check if the update was successful
                if (result.Succeeded)
                {
                    // Return updated user information
                    // Creating an anonymous object with updated user information
                    var updatedUserInfo = new
                    {
                        UserId = ervaringsdeskundige.Id,
                        UserName = ervaringsdeskundige.UserName,
                        Naam = ervaringsdeskundige.Naam,
                        Emailadres = ervaringsdeskundige.Email,
                        // ... return other properties as needed
                    };
                    // Return the updated user information
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

        // GET method to retrieve the claimed researches of the current user
        [HttpGet("claimed")]
        public async Task<ActionResult<IEnumerable<Onderzoek>>> GetClaimedOnderzoeken()
        {
            var userId = User.FindFirst("Id")?.Value; // Retrieve the user's ID from claims

            // Return an unauthorized response if the user is not authenticated
            if (userId == null)
            {
                return Unauthorized("User not authenticated");
            }

            // Retrieve onderzoeken claimed by the current user
            var claimedOnderzoeken = await _context.EnrolledErvaringsdeskundigen
                .Where(e => e.ErvaringsdeskundigeId == userId)
                .Select(e => e.Onderzoek)
                .ToListAsync();

            // Return the claimed researches
            return claimedOnderzoeken;
        }

        // DELETE method to remove a claimed onderzoek for the current user
        [HttpDelete("claimed/{onderzoekId}")]
        public async Task<IActionResult> RemoveClaimedOnderzoek(int onderzoekId)
        {
            // Retrieve the user's ID from claims
            var userId = User.FindFirst("Id")?.Value; // Retrieve the user's ID from claims

            // Retrieve the enrollment for the specified onderzoek and user
            var enrollment = await _context.EnrolledErvaringsdeskundigen
                .FirstOrDefaultAsync(e => e.ErvaringsdeskundigeId == userId && e.OnderzoekId == onderzoekId);

            // Return a 404 response if the onderzoek is not found in claimed list
            if (enrollment == null)
            {
                return NotFound("Onderzoek not found in claimed list");
            }

            // Remove the enrollment and save changes to the database
            _context.EnrolledErvaringsdeskundigen.Remove(enrollment);
            await _context.SaveChangesAsync();

            // Return a successful response
            return NoContent();
        }

        // POST method to enroll the current user in a specified onderzoek
        [HttpPost("enroll-in-onderzoek/{onderzoekId}")]
        public async Task<IActionResult> EnrollInOnderzoek(int onderzoekId)
        {
            try
            {
                // Retrieve the user's ID from claims
                var userId = User.FindFirst("Id")?.Value;

                // Find the user in the database
                var user = await _userManager.FindByIdAsync(userId);

                // Return a 404 response if the user is not found
                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Use a transaction to ensure atomicity
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        // Check if the user is already enrolled in the onderzoek
                        if (_context.EnrolledErvaringsdeskundigen.Any(e => e.ErvaringsdeskundigeId == userId && e.OnderzoekId == onderzoekId))
                        {
                            return BadRequest("User is already enrolled in this onderzoek");
                        }

                        // Check if the onderzoek is already claimed by another user
                        if (_context.EnrolledErvaringsdeskundigen.Any(e => e.OnderzoekId == onderzoekId))
                        {
                            return BadRequest("Onderzoek is already claimed by another user");
                        }

                        // Get the onderzoek
                        var onderzoek = await _context.Onderzoeken.FindAsync(onderzoekId);

                        if (onderzoek == null)
                        {
                            return NotFound("Onderzoek not found");
                        }

                        // Create a new entry in the EnrolledErvaringsdeskundigen table
                        var enrollment = new ErvaringsdeskundigeOnderzoek
                        {
                            ErvaringsdeskundigeId = userId,
                            OnderzoekId = onderzoekId
                        };

                        _context.EnrolledErvaringsdeskundigen.Add(enrollment);
                        _logger.LogInformation("Enrolling user {UserId} in onderzoek {OnderzoekId}", userId, onderzoekId);


                        // Save changes to the database
                        await _context.SaveChangesAsync();

                        _logger.LogInformation("Committing database transaction for user {UserId} and onderzoek {OnderzoekId}", userId, onderzoekId);

                        // Commit the transaction
                        transaction.Commit();

                        return Ok("Enrollment successful");
                    }
                    catch (Exception)
                    {
                        // An error occurred, rollback the transaction
                        transaction.Rollback();
                        throw; // Re-throw the exception for handling at the higher level
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            // Summary:
            // This method handles a POST request to enroll the current user in a specific onderzoek.
            // It follows a series of steps to ensure the enrollment process is reliable and consistent.

            // Step 1: Retrieve user information
            // - Extract the user's ID from the claims.
            // - Use the UserManager to fetch the corresponding user from the database.

            // Step 2: Initiate a transaction
            // - Start a transaction to ensure atomicity, guaranteeing that either all changes are committed or none.

            // Step 3: Check enrollment status
            // - Within the transaction, verify if the user is already enrolled in the specified onderzoek.
            // - Also, check if the onderzoek is already claimed by another user.

            // Step 4: Process enrollment
            // - If the user is not enrolled and the onderzoek is not claimed, proceed to retrieve the onderzoek from the database.
            // - Create a new enrollment entry and add it to the EnrolledErvaringsdeskundigen table.
            // - Save the changes to the database.

            // Step 5: Handle errors and exceptions
            // - If any error occurs during the process, roll back the transaction to maintain consistency.
            // - Return appropriate responses based on the success or failure of the enrollment process.
            // - Catch exceptions to handle unexpected errors and return a 500 Internal Server Error in such cases.
        }
    }
}



