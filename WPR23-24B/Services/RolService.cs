using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Services
{
    public class RolService : IRolService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Gebruiker> _userManager;

        public RolService(RoleManager<IdentityRole> roleManager, UserManager<Gebruiker> userManager) // Add UserManager to the constructor
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task InitializeRoles()
        {
            // Initialize roles if they do not exist
            var roles = new List<string> { "Admin", "Ervaringsdeskundige", "Bedrijf" };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public async Task<string> GetUserRole(Gebruiker user)
        {
            // Retrieve and return the role of a user
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.FirstOrDefault();
        }
    }
}