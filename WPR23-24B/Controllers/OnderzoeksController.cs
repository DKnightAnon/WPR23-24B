﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Models.Onderzoek;

namespace WPR23_24B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnderzoeksController : ControllerBase
    {
        private readonly OnderzoekContext _context;
        private readonly UserManager<IdentityUser> _manager;

        public OnderzoeksController(OnderzoekContext context, UserManager<IdentityUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        // GET-Methode om alle onderzoeken op te halen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Onderzoek>>> GetOnderzoek()
        {
            // Controleer of de Onderzoek entiteit niet null is
            if (_context.Onderzoek == null)
            {
                return NotFound();
            }
            // Haal alle onderzoeken op uit de database en retourneer ze
            return await _context.Onderzoek.ToListAsync();
        }

        // GET-Methode om een specifiek onderzoek op te halen aan de hand van het Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Onderzoek>> GetOnderzoekById(int id)
        {
            // Controleer of de Onderzoek entiteitset niet leeg is
            if (_context.Onderzoek == null)
            {
                return NotFound();
            }
            // Zoek het onderzoek met het opgegeven Id
            var onderzoek = await _context.Onderzoek.FindAsync(id);

            // Return 404 als het onderzoek niet is gevonden
            if (onderzoek == null)
            {
                return NotFound();
            }

            // Retourneer het gevonden onderzoek
            return onderzoek;
        }

        // PUT-Methode om een bestaand onderzoek bij te werken
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnderzoekById(int id, Onderzoek onderzoek)
        {
            // Controleer of het opgegeven Id overeenkomt met het Id in het model
            if (id != onderzoek.Id)
            {
                return BadRequest();
            }

            // Markeer het Onderzoek object als gemodificeerd
            _context.Entry(onderzoek).State = EntityState.Modified;

            try
            {
                // Sla de wijzigingen op in de database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Controleer of het Onderzoek object met het opgegeven Id bestaat
                if (!OnderzoekExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Retourneer succes (204 No Content)
            return NoContent();
        }

        // Methode om een nieuw onderzoek toe te voegen
        [HttpPost]
        public async Task<ActionResult<Onderzoek>> PostNieuwOnderzoek(Onderzoek onderzoek)
        {
            // Controleer of de Onderzoek entiteit niet null is
            if (_context.Onderzoek == null)
            {
                return Problem("Entity set 'OnderzoekContext.Onderzoek' is null.");
            }

            // Voeg het nieuwe Onderzoek object toe aan de entiteitset
            _context.Onderzoek.Add(onderzoek);

            // Sla wijzigingen op in de database
            await _context.SaveChangesAsync();

            // Retourneer het aangemaakte Onderzoek object met een 201 Created status
            return CreatedAtAction("GetOnderzoek", new { id = onderzoek.Id }, onderzoek);
        }

        // DELETE-methode om een onderzoek te verwijderen aan de hand van het Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnderzoekById(int id)
        {
            // Controleer of de Onderzoek entiteit niet null is
            if (_context.Onderzoek == null)
            {
                return NotFound();
            }

            // Zoek het onderzoek met het opgegeven Id
            var onderzoek = await _context.Onderzoek.FindAsync(id);

            // Return 404 als het onderzoek niet is gevonden
            if (onderzoek == null)
            {
                return NotFound();
            }

            // Verwijder het onderzoek uit de entiteitset
            _context.Onderzoek.Remove(onderzoek);

            // Sla wijzigingen op in de database
            await _context.SaveChangesAsync();

            // Retourneer succes (204 No Content)
            return NoContent();
        }

        // Methode om te controleren of een onderzoek met een bepaald Id bestaat
        private bool OnderzoekExists(int id)
        {
            return (_context.Onderzoek?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}