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

        // GET: api/Hulpmiddels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hulpmiddel>>> GetAllHulpmiddel()
        {
          if (_context.Hulpmiddel == null)
          {
              return NotFound();
          }
            return await _context.Hulpmiddel.ToListAsync();
        }

        // GET: api/Hulpmiddels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hulpmiddel>> GetHulpmiddelAtId(int id)
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

            return hulpmiddel;
        }

        // PUT: api/Hulpmiddels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHulpmiddel(int id, Hulpmiddel hulpmiddel)
        {
            if (id != hulpmiddel.Id)
            {
                return BadRequest();
            }

            _context.Entry(hulpmiddel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HulpmiddelExists(id))
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

        // POST: api/Hulpmiddels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // DELETE: api/Hulpmiddels/5
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
