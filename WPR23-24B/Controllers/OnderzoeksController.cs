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
    public class OnderzoeksController : ControllerBase
    {
        private readonly OnderzoekContext _context;

        public OnderzoeksController(OnderzoekContext context)
        {
            _context = context;
        }

        // GET: api/Onderzoeks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Onderzoek>>> GetOnderzoek()
        {
          if (_context.Onderzoek == null)
          {
              return NotFound();
          }
            return await _context.Onderzoek.ToListAsync();
        }

        // GET: api/Onderzoeks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Onderzoek>> GetOnderzoek(int id)
        {
          if (_context.Onderzoek == null)
          {
              return NotFound();
          }
            var onderzoek = await _context.Onderzoek.FindAsync(id);

            if (onderzoek == null)
            {
                return NotFound();
            }

            return onderzoek;
        }

        // PUT: api/Onderzoeks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnderzoek(int id, Onderzoek onderzoek)
        {
            if (id != onderzoek.Id)
            {
                return BadRequest();
            }

            _context.Entry(onderzoek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnderzoekExists(id))
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

        // POST: api/Onderzoeks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Onderzoek>> PostOnderzoek(Onderzoek onderzoek)
        {
          if (_context.Onderzoek == null)
          {
              return Problem("Entity set 'OnderzoekContext.Onderzoek'  is null.");
          }
            _context.Onderzoek.Add(onderzoek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOnderzoek", new { id = onderzoek.Id }, onderzoek);
        }

        // DELETE: api/Onderzoeks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnderzoek(int id)
        {
            if (_context.Onderzoek == null)
            {
                return NotFound();
            }
            var onderzoek = await _context.Onderzoek.FindAsync(id);
            if (onderzoek == null)
            {
                return NotFound();
            }

            _context.Onderzoek.Remove(onderzoek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OnderzoekExists(int id)
        {
            return (_context.Onderzoek?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
