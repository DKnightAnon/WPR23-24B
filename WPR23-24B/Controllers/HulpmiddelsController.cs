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
    public class HulpmiddelsController : ControllerBase
    {
        private readonly HulpmiddelContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HulpmiddelsController(HulpmiddelContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: Alle hulpmiddelen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hulpmiddel>>> GetAllHulpmiddel()
        {
            //Controleer of hulpmiddel leeg is 
          if (_context.Hulpmiddel == null)
          {
              return NotFound();
          }
          // Haal alle hulpmiddelen op in een lijst
            return await _context.Hulpmiddel.ToListAsync();
        }

        // GET: Hulpmiddel op basis van Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Hulpmiddel>> GetHulpmiddelAtId(int id)
        {
            // Controleer of hulpmiddel leeg is 
          if (_context.Hulpmiddel == null)
          {
              return NotFound();
          }
            var hulpmiddel = await _context.Hulpmiddel.FindAsync(id);

            // Kijk of er een overeenkomend hulpmiddel is 
            if (hulpmiddel == null )
            {
                return NotFound($"Geen hulpmiddel gevonden met het id {id}." );
            }
            //http Ok
            return Ok(hulpmiddel);
        }

        // PUT: Bijwerken van een hulpmiddel
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHulpmiddel(int id, Hulpmiddel hulpmiddel)
        {
            // Overeenkomst bekijken tussen id en id van hulpmiddel
            if (id != hulpmiddel.Id)
            {
                return BadRequest();
            }

            _context.Entry(hulpmiddel).State = EntityState.Modified;

            try
            {
                //Sla wijzigingen op 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Kijk of het hulpmiddel nog bestaat 
                if (!_context.Hulpmiddel.Any(b => b.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        
        }

        // POST: nieuwe hulpmiddelen toevoegen 
        [HttpPost]
        public async Task<ActionResult<Hulpmiddel>> PostNewHulpmiddel(Hulpmiddel hulpmiddel)
        {
          if (_context.Hulpmiddel == null)
          {
              return Problem("Entity set 'HulpmiddelContext.Hulpmiddel'  is null.");
          }
            _context.Hulpmiddel.Add(hulpmiddel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHulpmiddel", new { id = hulpmiddel.Id }, hulpmiddel);
        }

        // DELETE: verwijderen van een bestaand hulpmiddel 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHulpmiddel(int id)
        {
            if (_context.Hulpmiddel == null)
            {
                return NotFound();
            }
            var hulpmiddel = await _context.Hulpmiddel.FindAsync(id);
            if (hulpmiddel == null)
            {
                return NotFound();
            }

            // Verwijdert de beperking en slaat de wijzigingen op in de database
            _context.Hulpmiddel.Remove(hulpmiddel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HulpmiddelExists(int id)
        {
            return (_context.Hulpmiddel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
