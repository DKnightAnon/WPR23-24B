using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public BeperkingsController(BeperkingContext context)
        {
            _context = context;
        }

        // GET: api/Beperkings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beperking>>> GetBeperking()
        {
          if (_context.Beperking == null)
          {
              return NotFound();
          }
            return await _context.Beperking.ToListAsync();
        }

        // GET: api/Beperkings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beperking>> GetBeperking(int id)
        {
          if (_context.Beperking == null)
          {
              return NotFound();
          }
            var beperking = await _context.Beperking.FindAsync(id);

            if (beperking == null)
            {
                return NotFound();
            }

            return beperking;
        }

        // PUT: api/Beperkings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeperking(int id, Beperking beperking)
        {
            if (id != beperking.Id)
            {
                return BadRequest();
            }

            _context.Entry(beperking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeperkingExists(id))
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

        // POST: api/Beperkings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beperking>> PostBeperking(Beperking beperking)
        {
          if (_context.Beperking == null)
          {
              return Problem("Entity set 'BeperkingContext.Beperking'  is null.");
          }
            _context.Beperking.Add(beperking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeperking", new { id = beperking.Id }, beperking);
        }

        // DELETE: api/Beperkings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeperking(int id)
        {
            if (_context.Beperking == null)
            {
                return NotFound();
            }
            var beperking = await _context.Beperking.FindAsync(id);
            if (beperking == null)
            {
                return NotFound();
            }

            _context.Beperking.Remove(beperking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeperkingExists(int id)
        {
            return (_context.Beperking?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
