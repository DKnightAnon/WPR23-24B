using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Chat;
using WPR23_24B.Data;
using WPR23_24B.Models.Authenticatie;




namespace WPR23_24B.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ChatGebruikerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChatGebruikerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gebruiker>>> GetAllGebruikers()
        {

            if (_context.Gebruikers == null)
            {
                return NotFound();
            }

            var Gebruikers = await _context.Gebruikers.ToListAsync();

            return Ok(Gebruikers);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Gebruiker>> GetGebruikerAtID(string ID) 
        {
            if (_context.Gebruikers == null) { return Problem("Entity set Gebruiker is null."); }

            var gebruiker = _context.Gebruikers.FirstOrDefault(gebruikerid => gebruikerid.Id == ID);
            return gebruiker;
        }



        [HttpPost]
        public async Task<ActionResult<Gebruiker>> PostNieuweGebruiker(Gebruiker nieweGebruiker) 
        {
            if (_context.Gebruikers == null) { return Problem(detail: "Entity set Gebruiker is null."); }

            nieweGebruiker.UserName = nieweGebruiker.Naam;
            _context.Gebruikers.Add(nieweGebruiker);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetGebruiker", new {id = nieweGebruiker.Id}, nieweGebruiker);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGebruikerAtId(string id) 
        {
            if (_context.Gebruikers == null) { return Problem(detail: "Entity set Gebruiker is null."); }

            Gebruiker gebruikerVerwijder = _context.Gebruikers.Where(gebruiker => gebruiker.Id == id).FirstOrDefault();
            
             _context.Gebruikers.Remove(gebruikerVerwijder);
            await _context.SaveChangesAsync();

            return NotFound(); 

        }



    }
}
