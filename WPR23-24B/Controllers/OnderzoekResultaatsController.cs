using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Data;
using WPR23_24B.Models.Onderzoek;

namespace WPR23_24B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnderzoekResultaatsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OnderzoekResultaatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OnderzoekResultaats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Onderzoek_Resultaat>>> GetOnderzoekResultaat()
        {
            if (_context.OnderzoekResultaten == null)
            {
                return NotFound();
            }
            return await _context.OnderzoekResultaten.ToListAsync();
        }

        // GET: api/OnderzoekResultaats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Onderzoek_Resultaat>> GetOnderzoekResultaat(int id)
        {
            if (_context.OnderzoekResultaten == null)
            {
                return NotFound();
            }
            var onderzoekResultaat = await _context.OnderzoekResultaten.FindAsync(id);

            if (onderzoekResultaat == null)
            {
                return NotFound();
            }

            return onderzoekResultaat;
        }

        // PUT: api/OnderzoekResultaats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnderzoekResultaat(int id, Onderzoek_Resultaat onderzoekResultaat)
        {
            if (id != onderzoekResultaat.OnderzoekResultaatId)
            {
                return BadRequest();
            }

            _context.Entry(onderzoekResultaat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnderzoekResultaatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OnderzoekResultaats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Onderzoek_Resultaat>> PostOnderzoekResultaat(Onderzoek_Resultaat onderzoekResultaat)
        {
            if (_context.OnderzoekResultaten == null)
            {
                return Problem("Entity set 'OnderzoekResultaatContext.OnderzoekResultaat'  is null.");
            }
            _context.OnderzoekResultaten.Add(onderzoekResultaat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOnderzoekResultaat", new { id = onderzoekResultaat.OnderzoekResultaatId }, onderzoekResultaat);
        }

        // DELETE: api/OnderzoekResultaats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnderzoekResultaat(int id)
        {
            if (_context.OnderzoekResultaten == null)
            {
                return NotFound();
            }
            var onderzoekResultaat = await _context.OnderzoekResultaten.FindAsync(id);
            if (onderzoekResultaat == null)
            {
                return NotFound();
            }

            _context.OnderzoekResultaten.Remove(onderzoekResultaat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OnderzoekResultaatExists(int id)
        {
            return (_context.OnderzoekResultaten?.Any(e => e.OnderzoekResultaatId == id)).GetValueOrDefault();
        }
    }
}
