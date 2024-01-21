using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Data;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Models.Onderzoek;

namespace WPR23_24B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnderzoeksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Gebruiker> _manager;
        private readonly ILogger<OnderzoeksController> _logger;

        public OnderzoeksController(ApplicationDbContext context, UserManager<Gebruiker> manager, ILogger<OnderzoeksController> logger)
        {
            _context = context;
            _manager = manager;
            _logger = logger;
        }

        // GET-Methode om alle onderzoeken op te halen
        [Route("getAllItems")]
[HttpGet]
public async Task<ActionResult<IEnumerable<Onderzoek>>> GetOnderzoek()
{
    // Controleer of de Onderzoek entiteit niet null is
    if (_context.Onderzoeken == null)
    {
        return NotFound();
    }

    // Haal alle onderzoeken op uit de database
    var onderzoeken = await _context.Onderzoeken.ToListAsync();

    // Return een 200 OK status met de onderzoeken in JSON formaat
    return Ok(onderzoeken);
}

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Onderzoek>>> GetAvailableOnderzoeken()
        {
            var userId = User.FindFirst("Id")?.Value;

            // Retrieve the list of claimed researches
            var claimedOnderzoeken = await _context.EnrolledErvaringsdeskundigen
                .Select(e => e.OnderzoekId)
                .ToListAsync();

            // Retrieve the list of available researches excluding those claimed by any user
            var availableOnderzoeken = await _context.Onderzoeken
                .Where(o => !claimedOnderzoeken.Contains(o.Id))
                .ToListAsync();

            return availableOnderzoeken;
        }


        // GET-Methode om geclaimde onderzoeken voor een specifieke expert op te halen
        [HttpGet("claimed/{userId}")]
        public async Task<ActionResult<IEnumerable<Onderzoek>>> GetClaimedOnderzoeken(string userId)
        {
            var claimedOnderzoeken = await _context.EnrolledErvaringsdeskundigen
                .Where(e => e.ErvaringsdeskundigeId == userId)
                .Select(e => e.Onderzoek)
                .ToListAsync();

            return claimedOnderzoeken;
        }

        // GET-Methode om een specifiek onderzoek op te halen aan de hand van het Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Onderzoek>> GetOnderzoekById(int id)
        {
            // Controleer of de Onderzoek entiteitset niet leeg is
            if (_context.Onderzoeken == null)
            {
                return NotFound();
            }
            // Zoek het onderzoek met het opgegeven Id
            var onderzoek = await _context.Onderzoeken.FindAsync(id);

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

        [Route("addNewItem")]
        [HttpPost]
        public async Task<ActionResult<Onderzoek>> PostNieuwOnderzoek(Onderzoek onderzoek)
        {
            try
            {
                // Log the received data using ILogger
                _logger.LogInformation($"Received new research data: {Newtonsoft.Json.JsonConvert.SerializeObject(onderzoek)}");

                // Controleer of de Onderzoek entiteit niet null is
                if (_context.Onderzoeken == null)
                {
                    return Problem("Entity set 'OnderzoekContext.Onderzoek' is null.");
                }

                // Voeg het nieuwe Onderzoek object toe aan de entiteitset
                _context.Onderzoeken.Add(onderzoek);

                // Sla wijzigingen op in de database
                await _context.SaveChangesAsync();

                // Retourneer het aangemaakte Onderzoek object met een 201 Created status
                // return CreatedAtAction("GetOnderzoek", new { id = onderzoek.Id }, onderzoek);
                var response = new { OnderzoekId = onderzoek.Id, Titel = onderzoek.Titel };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception using ILogger
                _logger.LogError($"Error adding new research: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnderzoekById(int Id)
        {
            // Controleer of de Onderzoek entiteit niet null is
            if (_context.Onderzoeken == null)
            {
                return NotFound();
            }
            _logger.LogInformation($"Deleting research with ID: {Id}");

            // Zoek het onderzoek met het opgegeven Id
            var onderzoek = await _context.Onderzoeken.FindAsync(Id);

            // Return 404 als het onderzoek niet is gevonden
            if (onderzoek == null)
            {
                _logger.LogWarning($"Research with ID {Id} not found.");

                return NotFound();
            }

            // Verwijder het onderzoek uit de entiteitset
            _context.Onderzoeken.Remove(onderzoek);

            // Sla wijzigingen op in de database
            await _context.SaveChangesAsync();

            // Retourneer succes (204 No Content)
            return NoContent();
        }

        // Methode om te controleren of een onderzoek met een bepaald Id bestaat
        private bool OnderzoekExists(int id)
        {
            return (_context.Onderzoeken?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}