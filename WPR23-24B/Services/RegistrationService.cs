using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WPR23_24B.Data;
using WPR23_24B.DTO;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Models.Medisch;

namespace WPR23_24B.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<Gebruiker> _userManager;
        private readonly IRolService _rolService;
        private readonly ILogger<RegistrationService> _logger;
        private readonly ApplicationDbContext _context;

        public RegistrationService(
            UserManager<Gebruiker> userManager,
            IRolService rolService,
            ILogger<RegistrationService> logger,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _rolService = rolService;
            _logger = logger;
            _context = context;
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
                BenaderingCommercieel = model.BenaderingCommercieel,
                BenaderingPortal = model.BenaderingPortal,
                BenaderingTelefonisch = model.BenaderingTelefonisch
            };

            if (!model.IsJongerDan18 && model.Naam != null && model.TelefoonNummer != null && model.Email != null)
            {
                var voogd = new Voogd
                {
                    Naam = model.VoogdNaam,
                    Email = model.VoogdEmail,
                    TelefoonNummer = model.VoogdTelNummer
                };

                user.Voogd = voogd;
            }

            var result = await _userManager.CreateAsync(user, model.Wachtwoord);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Ervaringsdeskundige");

                // Associate disabilities with the user
                if (model.FysiekeBeperking || model.AuditieveBeperking || model.VisueleBeperking || !string.IsNullOrEmpty(model.AndereBeperking))
                {
                    var beperkingen = new List<ErvaringsdeskundigeBeperking>();

                    if (model.FysiekeBeperking)
                        beperkingen.Add(new ErvaringsdeskundigeBeperking { ErvaringsdeskundigeId = user.Id, BeperkingId = 1 }); // 1 is de ID voor "Fysiek"

                    if (model.AuditieveBeperking)
                        beperkingen.Add(new ErvaringsdeskundigeBeperking { ErvaringsdeskundigeId = user.Id, BeperkingId = 3 }); // 3 is de ID voor "Auditief"

                    if (model.VisueleBeperking)
                        beperkingen.Add(new ErvaringsdeskundigeBeperking { ErvaringsdeskundigeId = user.Id, BeperkingId = 2 }); // 2 is de ID voor "Visueel"

                    if (!string.IsNullOrEmpty(model.AndereBeperking))
                    {
                        // Voeg de "AndereBeperking" toe aan de database en haal de gegenereerde ID op
                        var andereBeperking = new Beperking { Name = model.AndereBeperking };
                        _context.Beperkingen.Add(andereBeperking);
                        await _context.SaveChangesAsync();
                        beperkingen.Add(new ErvaringsdeskundigeBeperking { ErvaringsdeskundigeId = user.Id, BeperkingId = andereBeperking.Id });
                    }

                    _context.ErvaringsdeskundigeBeperkingen.AddRange(beperkingen);
                    await _context.SaveChangesAsync();
                }
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
                BenaderingCommercieel = model.BenaderingCommercieel,
                BenaderingPortal = model.BenaderingPortal,
                BenaderingTelefonisch = model.BenaderingTelefonisch
            };

            var result = await _userManager.CreateAsync(user, model.Wachtwoord);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Ervaringsdeskundige");

                // Associate disabilities with the user
                if (model.FysiekeBeperking || model.AuditieveBeperking || model.VisueleBeperking || !string.IsNullOrEmpty(model.AndereBeperking))
                {
                    var beperkingen = new List<ErvaringsdeskundigeBeperking>();

                    if (model.FysiekeBeperking)
                        beperkingen.Add(new ErvaringsdeskundigeBeperking { ErvaringsdeskundigeId = user.Id, BeperkingId = 1 }); // 1 is de ID voor "Fysiek"

                    if (model.AuditieveBeperking)
                        beperkingen.Add(new ErvaringsdeskundigeBeperking { ErvaringsdeskundigeId = user.Id, BeperkingId = 3 }); // 3 is de ID voor "Auditief"

                    if (model.VisueleBeperking)
                        beperkingen.Add(new ErvaringsdeskundigeBeperking { ErvaringsdeskundigeId = user.Id, BeperkingId = 2 }); // 2 is de ID voor "Visueel"

                    if (!string.IsNullOrEmpty(model.AndereBeperking))
                    {
                        // Voeg de "AndereBeperking" toe aan de database en haal de gegenereerde ID op
                        var andereBeperking = new Beperking { Name = model.AndereBeperking };
                        _context.Beperkingen.Add(andereBeperking);
                        await _context.SaveChangesAsync();
                        beperkingen.Add(new ErvaringsdeskundigeBeperking { ErvaringsdeskundigeId = user.Id, BeperkingId = andereBeperking.Id });
                    }

                    _context.ErvaringsdeskundigeBeperkingen.AddRange(beperkingen);
                    await _context.SaveChangesAsync();
                }
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
                TelefoonNummer = model.TelefoonNummer,
                Website = model.Website,
                TrackingID = model.TrackingId,
                //ContactPersoon = model.Contactpersoon,
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
