using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;


        public BedrijfsController(BedrijfsContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //Haal een lijst op van Bedrijven met het overeenkomende id 
        // GET: api/Bedrijfs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bedrijf>> GetBedrijfAtId(int id)
        {
          // Haal bedrijvenn op met overeenkomend Id
          var bedrijven = await _context.Bedrijf.Where(b => b.Id == id).ToListAsync();

         //Kijk of er daadwerkelijk overeenkomsten zijn
            if (bedrijven == null || bedrijven.Count() == 0)
            {
                return NotFound();
            }
            // http ok, laat het eerste bedrijf zien 
            return Ok(bedrijven[0]);
        
        }

        // GET: api/BedrijfAllebedrijven
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bedrijf>>> GetAllBedrijven()
        {
            //haal alle bedrijven op
            var allBedrijven = await _context.Bedrijf.ToListAsync();
                
            //Controleer of het niet null is 
            if(allBedrijven== null || allBedrijven.Count() == 0){
                return NotFound();
            }

            return Ok(allBedrijven);
        }
            

        // PUT: api/Bedrijfs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBedrijf(int id, Bedrijf bedrijf)
        {
            if (id != bedrijf.Id)
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

        // POST: voor het toevoegen van een nieuw bedrijf 
        [HttpPost]
        public async Task<ActionResult<Bedrijf>> PostBedrijf(Bedrijf bedrijf)
        {

        //Controleer of bedrijf niet null is 
          if (_context.Bedrijf == null)
          {
              return Problem("Entity set 'BedrijfsContext.Bedrijf'  is null.");
          }
          //Voeg nieuw bedrijf toe en sla op
            _context.Bedrijf.Add(bedrijf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBedrijf", new { id = bedrijf.Id }, bedrijf);
        }


        //PATCH: voor het bijwerken van een bestaan bedrijf op basis van het id
        [HttpPatch]
        public async Task<IActionResult> UpdateBedrijf(int id, [FromBody] Dictionary<string,object> updates)
        {
            //Zoek bedrijf op basis van opgegeven id
            var bedrijf = await _context.Bedrijf.FindAsync(id);

            //Controleer of de beperking is gevonden
            if (bedrijf == null)
            {
                return NotFound();
            }

            //Pas gegevens van bedrijf aan
            foreach (var update in updates)
            {
                var property = bedrijf.GetType().GetProperty(update.Key);

                if(property != null && property.CanWrite)
                {
                    property.SetValue(bedrijf, Convert.ChangeType(update.Value, property.PropertyType)); 
                } 
            }

            //Sla de wijzigingen op in de database
            await _context.SaveChangesAsync();

            //http ok
            return Ok(bedrijf);
        }



        // DELETE: voor het verwijderen van een bestaand bedrijf
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBedrijfAtId(int id)
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

        private bool BedrijfExists(int id)
        {
            return (_context.Bedrijf?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }





}
