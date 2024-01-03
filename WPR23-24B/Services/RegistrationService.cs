using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WPR23_24B.DTO;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<Gebruiker> _userManager;
        private readonly IRolService _rolService;
        private readonly ILogger<RegistrationService> _logger;

        public RegistrationService(
            UserManager<Gebruiker> userManager,
            IRolService rolService,
            ILogger<RegistrationService> logger)
        {
            _userManager = userManager;
            _rolService = rolService;
            _logger = logger;
        }

        public async Task<IdentityResult> RegisterUnder18Async(RegisterUnder18DTO model)
        {
            var user = new Ervaringsdeskundige
            {
                // Populate user properties based on registration model
                UserName = model.Email,
                Email = model.Email,
                Naam = model.Naam,
                Postcode = model.Postcode,
                GeboorteDatum = model.GeboorteDatum,
                IsJongerDan18 = true,
                TelefoonNummer = model.TelefoonNummer,

                FysiekeBeperking = model.FysiekeBeperking,
                AuditieveBeperkin = model.AuditieveBeperkin,
                VisueleBeperking = model.VisueleBeperking,
                AndereBeperking = model.AndereBeperking,

                BenaderingCommercieel = model.BenaderingCommercieel,
                BenaderingPortal = model.BenaderingPortal,
                BenaderingTelefonisch = model.BenaderingTelefonisch
            };

            if (!model.IsJongerDan18 && model.Naam != null && model.TelefoonNummer != null && model.Email != null)
            {
                var voogd = new Voogd
                {
                    Naam = model.Naam,
                    Email = model.Email,
                    TelefoonNummer = model.TelefoonNummer
                };

                user.Voogd = voogd;
            }

            var result = await _userManager.CreateAsync(user, model.Wachtwoord);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Ervaringsdeskundige");
            }

            return result;
        }

        public async Task<IdentityResult> RegisterOver18Async(RegisterOver18DTO model)
        {
            var user = new Ervaringsdeskundige
            {
                // Populate user properties based on registration model
                UserName = model.Email,
                Email = model.Email,
                Naam = model.Naam,
                Postcode = model.Postcode,
                GeboorteDatum = model.GeboorteDatum,
                IsJongerDan18 = false,

                TelefoonNummer = model.TelefoonNummer,
                FysiekeBeperking = model.FysiekeBeperking,
                AuditieveBeperkin = model.AuditieveBeperkin,
                VisueleBeperking = model.VisueleBeperking,
                AndereBeperking = model.AndereBeperking,

                BenaderingCommercieel = model.BenaderingCommercieel,
                BenaderingPortal = model.BenaderingPortal,
                BenaderingTelefonisch = model.BenaderingTelefonisch
            };

            if (!model.IsJongerDan18 && model.Naam != null && model.TelefoonNummer != null && model.Email != null)
            {
                var voogd = new Voogd
                {
                    Naam = model.Naam,
                    Email = model.Email,
                    TelefoonNummer = model.TelefoonNummer
                };

                user.Voogd = voogd;
            }

            var result = await _userManager.CreateAsync(user, model.Wachtwoord);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Ervaringsdeskundige");
            }

            return result;
        }

        public async Task<IdentityResult> RegisterCompanyAsync(RegisterCompanyDTO model)
        {
            _logger.LogInformation($"Registering company with email: {model.Email}, name: {model.Naam}, phonenumber: {model.TelefoonNummer}");

            var company = new Bedrijf
            {
                Email = model.Email,
                UserName = "Company_" + Guid.NewGuid().ToString(),
                Naam = model.Naam,
                Postcode = model.Postcode,
                PhoneNumber = model.TelefoonNummer,
                Website = model.Website,
                TrackingID = model.TrackingId,
                ContactPersoon = model.Contactpersoon,
                Locatie = model.Postcode
            };

            var result = await _userManager.CreateAsync(company, model.Wachtwoord);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(company, "Bedrijf");
            }

            return result;
        }
    }
}
