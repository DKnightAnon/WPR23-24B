using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Data;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedrijfsController : ControllerBase
    {
        private readonly BedrijfsContext _context;

        public BedrijfsController(BedrijfsContext context)
        {
            _context = context;
        }

        // GET: api/Bedrijfs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bedrijf>>> GetBedrijf()
        {
          if (_context.Bedrijf == null)
          {
              return NotFound();
          }
            return await _context.Bedrijf.ToListAsync();
        }

        // GET: api/Bedrijfs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bedrijf>> GetBedrijf(int id)
        {
          if (_context.Bedrijf == null)
          {
              return NotFound();
          }
            var bedrijf = await _context.Bedrijf.FindAsync(id);

            if (bedrijf == null)
            {
                return NotFound();
            }

            return bedrijf;
        }

        // PUT: api/Bedrijfs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBedrijf(Guid id, Bedrijf bedrijf)
        {
            if (id.ToString() != bedrijf.Id)
            {
                return BadRequest();
            }

            _context.Entry(bedrijf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BedrijfExists(id))
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

        // POST: api/Bedrijfs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bedrijf>> PostBedrijf(Bedrijf bedrijf)
        {
          if (_context.Bedrijf == null)
          {
              return Problem("Entity set 'WPR23_24BContext.Bedrijf'  is null.");
          }
            _context.Bedrijf.Add(bedrijf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBedrijf", new { id = bedrijf.Id }, bedrijf);
        }

        // DELETE: api/Bedrijfs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBedrijf(int id)
        {
            if (_context.Bedrijf == null)
            {
                return NotFound();
            }
            var bedrijf = await _context.Bedrijf.FindAsync(id);
            if (bedrijf == null)
            {
                return NotFound();
            }

            _context.Bedrijf.Remove(bedrijf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BedrijfExists(Guid id)
        {
            return (_context.Bedrijf?.Any(e => e.Id == id.ToString())).GetValueOrDefault();
        }
    }
}

