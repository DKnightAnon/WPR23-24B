using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Models.Medisch;

namespace WPR23_24B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeperkingsController : ControllerBase
    {
        private readonly BeperkingContext _context;
        private readonly UserManager<IdentityUser> _manager;

        public BeperkingsController(BeperkingContext context, UserManager<IdentityUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        /// Haalt een lijst op van Beperkingen die overeenkomen met de opgegeven naam.
        [HttpGet("GetBeperkingenByNaam/{naam}")]
        public async Task<ActionResult<IEnumerable<Beperking>>> GetBeperkingenByNaam(string naam)
        {
            // Haal Beperkingen op die de opgegeven naam bevatten
            var beperkingen = await _context.Beperkingen
                .Where(b => b.Name.Contains(naam))
                .ToListAsync();

            // Verifieer of er Beperkingen zijn gevonden met de specifiek opgegeven naam
            if (beperkingen == null || beperkingen.Count == 0)
            {
                return NotFound($"Geen beperkingen gevonden met de naam {naam}.");
            }

            return Ok(beperkingen);
        }

        // Haalt een lijst op van alle Beperkingen.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beperking>>> GetAllBeperking()
        {
            // Controleer of de Beperkingen-entiteit niet null is
            if (_context.Beperkingen == null)
            {
                return NotFound();
            }
            // Haal alle beperkingen op en sla deze op in een List
            return await _context.Beperkingen.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beperking>>> GetAllBeperkingen()
        {
            var beperkingen = await _context.Beperkingen.ToListAsync();

            if (beperkingen == null)
            {
                return NotFound();
            }

            return Ok(beperkingen);
        }

        /// Haalt een specifieke Beperking op basis van het opgegeven id.
        // GET: api/Beperkings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beperking>> GetBeperking(int id)
        {
            // Controleer of de Beperkingen-entiteit niet null is
            if (_context.Beperkingen == null)
            {
                return NotFound();
            }
            // Haal de Beperking op met het opgegeven id
            var beperking = await _context.Beperkingen.FindAsync(id);

            // Haal de Beperking op met het opgegeven id
            if (beperking == null)
            {
                return NotFound();
            }

            return beperking;
        }

        // Haalt Beperkingen op die zijn gekoppeld aan de gebruiker via GebruikerList.
        [HttpGet("{id}")]
        public async Task<ActionResult<Beperking>> GetBeperkingenVanGebruiker(string gebruikerId)
        {
            // Zoek de gebruiker op basis van het opgegeven gebruikerId
            var gebruiker = await _manager.FindByIdAsync(gebruikerId.ToString());

            if (gebruiker == null)
            {
                return NotFound($"Gebruiker met {gebruikerId} niet gevonden.");
            }

            // Haal Beperkingen op die gekoppeld zijn aan de gebruiker via GebruikerList
            var beperkingen = _context.Beperkingen
                .Where(b => b.GebruikerList.Any(g => g.Id.Contains(gebruikerId)))
                .ToList();

            return Ok(beperkingen);
        }
        // PUT-methode voor het bijwerken van een bestaande Beperking.
        // PUT: api/Beperkings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeperking(int id, Beperking beperking)
        {
            // Controleer of het opgegeven id overeenkomt met het id van de Beperking
            if (id != beperking.Id)
            {
                return BadRequest();
            }
            // Markeer de Beperking als gewijzigd in de context.
            _context.Entry(beperking).State = EntityState.Modified;

            try
            {
                // Sla de wijzigingen op in de database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Controleer of de Beperking nogsteeds bestaat 
                if (!_context.Beperkingen.Any(b => b.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            // TODO:
            // Verdere implementatie van deze methoden en return waarden.
            return Ok();
        }
        // POST-methode voor het toevoegen van een nieuwe Beperking.
        // POST: api/Beperkings
        [HttpPost]
        public async Task<ActionResult<Beperking>> PostBeperking(Beperking beperking)
        {
            // Controleer of de Beperkingen-entiteit niet null is
            if (_context.Beperkingen == null)
            {
                return Problem("Entity set 'BeperkingContext.Beperking' is null.");
            }
            // Voeg de nieuwe Beperking toe aan de context en sla deze op in de database
            _context.Beperkingen.Add(beperking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeperking", new { id = beperking.Id }, beperking);
        }

        // DELETE-methode voor het verwijderen van een bestaande Beperking.
        // DELETE: api/Beperkings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeperking(int id)
        {
            // Controleer of de Beperkingen-entiteit niet null is
            if (_context.Beperkingen == null)
            {
                return NotFound();
            }
            // Zoek de Beperking op basis van het opgegeven id
            var beperking = await _context.Beperkingen.FindAsync(id);
            
            // Controleer of de Beperking is gevonden
            if (beperking == null)
            {
                return NotFound();
            }

            // Verwijder de Beperking uit de context en sla de wijzigingen op in de database
            _context.Beperkingen.Remove(beperking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // [HttpDelete("DeleteBeperkingFromGebruiker")]
        // public async Task<IActionResult> DeleteBeperkingFromGebruiker(int gebruikerId, int beperkingId)
        // {
        //     var gebruiker = await _manager.FindByIdAsync(gebruikerId.ToString());

        //     if (gebruiker == null)
        //     {
        //         return NotFound($"Gebruiker met ID {gebruikerId} niet gevonden.");
        //     }

        //     var beperking = await _context.Beperkingen.FindAsync(beperkingId);

        //     if (beperking == null)
        //     {
        //         return NotFound($"Beperking met ID {beperkingId} niet gevonden.");
        //     }

        //     gebruiker.Beper.Remove(beperking);
        //     await _manager.UpdateAsync(gebruiker);

        //     return NoContent();
        // }

        // PATCH-methode voor het bijwijerken van een bestaande Beperking op basis van het opgegeven id en dictionary met updates.
        [HttpPatch("UpdateBeperking/{id}")]
        public async Task<IActionResult> UpdateBeperking(int id, [FromBody] Dictionary<string, object> updates)
        {
            // Zoek de Beperking op basis van het opgegeven id
            var beperking = await _context.Beperkingen.FindAsync(id);

            // Controleer of de Beperking is gevonden
            if (beperking == null)
            {
                return NotFound();
            }

            // Pas de eigenschappen van de Beperking aan op basis van de opgegeven updates
            foreach (var update in updates)
            {
                var property = beperking.GetType().GetProperty(update.Key);

                if (property != null && property.CanWrite)
                {
                    property.SetValue(beperking, Convert.ChangeType(update.Value, property.PropertyType));
                }
            }
            // Sla de wijzigingen op in de database
            await _context.SaveChangesAsync();

            return Ok(beperking);
        }

        // TODO: Voeg hier andere controller methoden toe indien nodig
        private bool BeperkingExists(int id)
        {
            // Controleer of een Beperking met het opgegeven id bestaat
            return (_context.Beperkingen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
