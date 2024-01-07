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
    public class BedrijfController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BedrijfController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bedrijfs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bedrijf>>> GetBedrijf()
        {
            if (_context.Bedrijven == null)
            {
                return NotFound();
            }
            return await _context.Bedrijven.ToListAsync();
        }

        // GET: api/Bedrijfs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bedrijf>> GetBedrijf(int id)
        {
            if (_context.Bedrijven == null)
            {
                return NotFound();
            }
            var bedrijf = await _context.Bedrijven.FindAsync(id);

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
            Console.WriteLine($"Id from URL : " + id);
            Console.WriteLine("Bedrijf details are : " + bedrijf);

            if (id.ToString() != bedrijf.Id)
            {
                return BadRequest("Bedrijf ID komt niet overeen");
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
            if (_context.Bedrijven == null)
            {
                return Problem("Entity set 'WPR23_24BContext.Bedrijf'  is null.");
            }
            _context.Bedrijven.Add(bedrijf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBedrijf", new { id = bedrijf.Id }, bedrijf);
        }

        // DELETE: api/Bedrijfs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBedrijf(int id)
        {
            if (_context.Bedrijven == null)
            {
                return NotFound();
            }
            var bedrijf = await _context.Bedrijven.FindAsync(id);
            if (bedrijf == null)
            {
                return NotFound();
            }

            _context.Bedrijven.Remove(bedrijf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BedrijfExists(Guid id)
        {
            return (_context.Bedrijven?.Any(e => e.Id == id.ToString())).GetValueOrDefault();
        }
    }
}