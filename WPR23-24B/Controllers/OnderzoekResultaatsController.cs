using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Models.Onderzoek;

namespace WPR23_24B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnderzoekResultaatsController : ControllerBase
    {
        private readonly OnderzoekResultaatContext _context;

        public OnderzoekResultaatsController(OnderzoekResultaatContext context)
        {
            _context = context;
        }

        // GET: api/OnderzoekResultaats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OnderzoekResultaat>>> GetOnderzoekResultaat()
        {
          if (_context.OnderzoekResultaat == null)
          {
              return NotFound();
          }
            return await _context.OnderzoekResultaat.ToListAsync();
        }

        // GET: api/OnderzoekResultaats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OnderzoekResultaat>> GetOnderzoekResultaat(int id)
        {
          if (_context.OnderzoekResultaat == null)
          {
              return NotFound();
          }
            var onderzoekResultaat = await _context.OnderzoekResultaat.FindAsync(id);

            if (onderzoekResultaat == null)
            {
                return NotFound();
            }

            return onderzoekResultaat;
        }

        // PUT: api/OnderzoekResultaats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnderzoekResultaat(int id, OnderzoekResultaat onderzoekResultaat)
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
        public async Task<ActionResult<OnderzoekResultaat>> PostOnderzoekResultaat(OnderzoekResultaat onderzoekResultaat)
        {
          if (_context.OnderzoekResultaat == null)
          {
              return Problem("Entity set 'OnderzoekResultaatContext.OnderzoekResultaat'  is null.");
          }
            _context.OnderzoekResultaat.Add(onderzoekResultaat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOnderzoekResultaat", new { id = onderzoekResultaat.OnderzoekResultaatId }, onderzoekResultaat);
        }

        // DELETE: api/OnderzoekResultaats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnderzoekResultaat(int id)
        {
            if (_context.OnderzoekResultaat == null)
            {
                return NotFound();
            }
            var onderzoekResultaat = await _context.OnderzoekResultaat.FindAsync(id);
            if (onderzoekResultaat == null)
            {
                return NotFound();
            }

            _context.OnderzoekResultaat.Remove(onderzoekResultaat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OnderzoekResultaatExists(int id)
        {
            return (_context.OnderzoekResultaat?.Any(e => e.OnderzoekResultaatId == id)).GetValueOrDefault();
        }
    }
}
